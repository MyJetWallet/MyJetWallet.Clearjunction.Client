using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Auth;
using MyJetWallet.ClearJunction.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using RestSharp;

namespace MyJetWallet.ClearJunction
{
    public partial class ClearJunctionClient : IDisposable, IClearJunctionClient
    {
        public static bool PrintGetApiCalls { get; set; } = false;
        public static bool PrintPostApiCalls { get; set; } = false;
        public static bool PrintPutApiCalls { get; set; } = false;

        #region Properties

        public string EndpointUrl { get; private set; }

        public bool ThrowThenErrorResponse { get; set; } = true;

        private RestClient _httpClient;
        private DateTime _lastHttpSetupTime;
        private RestClient _lastHttpClient;
        private readonly object _gate = new object();
        private readonly AuthChecker _authChecker;

        #endregion

        #region CTOR

        public ClearJunctionClient(string apiKey, string apiPassword, string apiRootUrl)
        {
            _authChecker = new AuthChecker(apiKey, apiPassword);
            if (string.IsNullOrEmpty(apiRootUrl))
                throw new ArgumentException("api url cannot be empty", nameof(apiRootUrl));

            if (apiRootUrl.Last() != '/')
                apiRootUrl += '/';

            this.EndpointUrl = apiRootUrl;
        }

        #endregion

        #region Private Methods

        private RestClient GetHttpClient()
        {
            lock (_gate)
            {
                if (_httpClient == null || (DateTime.UtcNow - _lastHttpSetupTime).TotalSeconds > 120)
                {
                    SetupHttpClient();
                }

                return _httpClient;
            }
        }

        private void SetupHttpClient()
        {
            var client = new RestClient(this.EndpointUrl);

            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("X-API-KEY", this._authChecker.ApiKey.SecureStringToString());

            _lastHttpClient?.Dispose();
            _lastHttpClient = _httpClient;
            _httpClient = client;
            _lastHttpSetupTime = DateTime.UtcNow;
        }

        private string ConvertToQueryString(Dictionary<string, object> nvc)
        {
            var array = nvc
                .Where(keyValue => keyValue.Value != null)
                .Select(keyValue =>
                    new KeyValuePair<string, string>(keyValue.Key, keyValue.Value.ConvertValueToString()))
                .Select(keyValue => $"{WebUtility.UrlEncode(keyValue.Key)}={WebUtility.UrlEncode(keyValue.Value)}")
                .ToArray();
            return array.Any() ? "?" + string.Join("&", array) : string.Empty;
        }

        public async Task<WebCallResult<T>> GetAsync<T>(string url,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.GetHttpClient();

            var request = new RestRequest(new System.Uri(url, System.UriKind.RelativeOrAbsolute), Method.Get);

            AddAuthToHeader(request, string.Empty);

            try
            {
                var response = await client
                    .ExecuteAsync(request, cancellationToken)
                    .ConfigureAwait(false);

                var status = (int)response.StatusCode;
                var content = response?.Content;
                if (status == 200)
                    return this.EvaluateResponse<T>(response, content);
                else
                    return this.EvaluateErrorResponse<T>(response, content);
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw;
            }
        }

        public async Task<WebCallResult<T>> PostAsync<T>(string url, object data,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = this.GetHttpClient();

            var request = new RestRequest(new System.Uri(url, System.UriKind.RelativeOrAbsolute), Method.Post);
            var cont = JsonConvert.SerializeObject(data);
            request.AddStringBody(cont, DataFormat.Json);
            AddAuthToHeader(request, cont);

            try
            {
                var response = await client
                    .ExecutePostAsync(request, cancellationToken)
                    .ConfigureAwait(false);

                var status = (int)response.StatusCode;
                var content = response?.Content;
                if (status == 200 || status == 201)
                    return this.EvaluateResponse<T>(response, content);
                else
                    return this.EvaluateErrorResponse<T>(response, content);
            }
            catch (System.Net.Http.HttpRequestException e)
            {
                throw;
            }
        }

        private void AddAuthToHeader(RestRequest request, string content)
        {
            var date = _authChecker.GetCurrentDate();
            var signature = _authChecker.GetSignature(date, content);

            request.AddHeader("Date", date);
            request.AddHeader("Authorization", signature);
        }

        private WebCallResult<T> EvaluateResponse<T>(RestResponse response, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ThrowErrorExceptionIfEnabled(HttpStatusCode.NotFound, "Empty Response");
                return new WebCallResult<T>(response, default, HttpStatusCode.NotFound, new ClearJunctionError()
                {
                    Errors = new[]
                    {
                        new ClearJunctionErrorItem()
                        {
                            Code = -1,
                            Details = "Empty Response",
                            Message = "Empty Response",
                        }
                    }
                });
            }

            return new WebCallResult<T>(response, JsonConvert.DeserializeObject<T>(content));
        }

        private WebCallResult<T> EvaluateErrorResponse<T>(RestResponse response, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ThrowErrorExceptionIfEnabled(response.StatusCode, "Empty Response");
                return new WebCallResult<T>(response, default, response.StatusCode, new ClearJunctionError()
                {
                    Errors = new[]
                    {
                        new ClearJunctionErrorItem()
                        {
                            Code = -1,
                            Details = "Empty Response",
                            Message = "Empty Response",
                        }
                    }
                });
            }

            if(!TryParseErrorResponse(content, out ClearJunctionError error))
            {
                ThrowErrorExceptionIfEnabled(response.StatusCode, content);
                return new WebCallResult<T>(response, default, response.StatusCode, new ClearJunctionError()
                {
                    Errors = new[]
                    {
                        new ClearJunctionErrorItem()
                        {
                            Code = -1,
                            Details = content,
                            Message = "Cannot parse error response",
                        }
                    }
                });
            }
            
            return new WebCallResult<T>(response, default, response.StatusCode, error);
        }

        bool TryParseErrorResponse(string content, out ClearJunctionError error)
        {
            // Check expected error keywords presence :
            if (!content.Contains("details") ||
                !content.Contains("message") ||
                !content.Contains("code"))
            {
                error = null;
                return false;
            }

            // Check json schema :
            var generator = new JSchemaGenerator();
            var schema = generator.Generate(typeof(ClearJunctionError));
            var jsonObject = JObject.Parse(content);
            if (!jsonObject.IsValid(schema))
            {
                error = null;
                return false;
            }

            error = JsonConvert.DeserializeObject<ClearJunctionError>(content);
            return true;
        }

        private void ThrowErrorExceptionIfEnabled(HttpStatusCode code, string message)
        {
            if (ThrowThenErrorResponse)
            {
                throw new ClearJunctionException(code, message);
            }
        }

        #endregion

        public void Dispose()
        {
            _httpClient?.Dispose();
            _lastHttpClient?.Dispose();
            _authChecker?.Dispose();
        }
    }
}