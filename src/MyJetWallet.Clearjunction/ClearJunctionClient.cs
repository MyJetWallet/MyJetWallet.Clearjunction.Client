using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MyJetWallet.ClearJunction
{

    public partial class ClearJunctionClient : IDisposable, IClearJunctionClient
    {
        public const string MainPublicApi = "";
        public const string TestPublicApi = "";

        public static bool PrintGetApiCalls { get; set; } = false;
        public static bool PrintPostApiCalls { get; set; } = false;
        public static bool PrintPutApiCalls { get; set; } = false;

        #region Properties

        public string EndpointUrl { get; private set; }

        public SecureString ApiKey { get; private set; }

        public SecureString ApiPassword { get; private set; }

        public bool ThrowThenErrorResponse { get; set; } = true;

        private RestClient _httpClient;
        private DateTime _lastHttpSetupTime;
        private RestClient _lastHttpClient;
        private readonly object _gate = new object();

        #endregion

        #region CTOR

        public ClearJunctionClient(string apiKey, string apiPassword, string apiRootUrl)
        {
            if (string.IsNullOrEmpty(apiRootUrl))
                throw new ArgumentException("api url cannot be empty", nameof(apiRootUrl));

            if (apiRootUrl.Last() != '/')
                apiRootUrl += '/';

            this.EndpointUrl = apiRootUrl;
            this.SetAccessToken(apiKey, apiPassword);
        }

        #endregion

        #region Api Key

        public void SetAccessToken(string apiKey, string apiPassword)
        {
            if (!string.IsNullOrEmpty(apiKey))
            {
                this.ApiKey = apiKey.StringToSecureString();
            }

            if (!string.IsNullOrEmpty(apiPassword))
            {
                this.ApiPassword = apiPassword.StringToSecureString();
            }
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
            client.AddDefaultHeader("X-API-KEY", this.ApiKey.SecureStringToString());

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
                    .GetAsync(request, cancellationToken)
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

        private void AddAuthToHeader(RestRequest request, string content)
        {
            var date = DateTime.UtcNow
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ss+00:00")
                .Replace(" ", "T");
            request.AddHeader("Date", date);

            using var shaM = SHA512.Create();

            var concatenated = this.ApiKey.SecureStringToString().ToUpperInvariant()
                               + date
                               + ToHex(shaM.ComputeHash(Encoding.UTF8.GetBytes(ApiPassword.SecureStringToString())))
                                   .ToUpperInvariant()
                               + content.ToUpperInvariant();
            
            var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(concatenated));

            var signature = ToHex(hash);

            request.AddHeader("Authorization", signature);
        }

        private WebCallResult<T> EvaluateResponse<T>(RestResponse response, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ThrowErrorExceptionIfEnabled(HttpStatusCode.NotFound, "Empty Response");
                return new WebCallResult<T>(response, default, HttpStatusCode.NotFound, new ClearJunctionError()
                {
                    Errors = new[] { new ClearJunctionErrorItem()
                    {
                        Code = -1,
                        Details = "Empty Response",
                        Message = "Empty Response",
                    } }
                });
            }

            return new WebCallResult<T>(response, JsonConvert.DeserializeObject<CallResult<T>>(content));
        }

        private WebCallResult<T> EvaluateErrorResponse<T>(RestResponse response, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                ThrowErrorExceptionIfEnabled(HttpStatusCode.NotFound, "Empty Response");
                return new WebCallResult<T>(response, default, HttpStatusCode.NotFound, new ClearJunctionError()
                {
                    Errors = new[] { new ClearJunctionErrorItem()
                    {
                        Code = -1,
                        Details = "Empty Response",
                        Message = "Empty Response",
                    } }
                });
            }

            return new WebCallResult<T>(response, default, response.StatusCode, JsonConvert.DeserializeObject<ClearJunctionError>(content));
        }

        private void ThrowErrorExceptionIfEnabled(HttpStatusCode code, string message)
        {
            if (ThrowThenErrorResponse)
            {
                throw new ClearJunctionException(code, message);
            }
        }

        public static string ToHex(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];

            byte b;

            for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
            {
                b = ((byte)(bytes[bx] >> 4));
                c[cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);

                b = ((byte)(bytes[bx] & 0x0F));
                c[++cx] = (char)(b > 9 ? b + 0x37 + 0x20 : b + 0x30);
            }

            return new string(c);
        }

        #endregion

        public void Dispose()
        {
            _httpClient?.Dispose();
            _lastHttpClient?.Dispose();
            ApiKey?.Dispose();
            ApiPassword?.Dispose();
        }
    }
}
