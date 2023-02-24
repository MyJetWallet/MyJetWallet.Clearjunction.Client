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

        private HttpClient _httpClient;
        private DateTime _lastHttpSetupTime;
        private HttpClient _lastHttpClient;
        private readonly object _gate = new object();

        #endregion

        #region CTOR

        public ClearJunctionClient(string apiKey, string apiPassword, string apiRootUrl)
        {
            if (string.IsNullOrEmpty(apiRootUrl))
                throw new ArgumentException("api url cannot be empty", nameof(apiRootUrl));

            if (apiRootUrl.Last() != '/')
                apiRootUrl += '/';

            apiRootUrl += "v1";

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

        private HttpClient GetHttpClient()
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
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            var client = new HttpClient(handler);

            client.BaseAddress = new Uri(this.EndpointUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-API-KEY", this.ApiKey.SecureStringToString());

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

            using var request = new System.Net.Http.HttpRequestMessage();

            request.Method = new System.Net.Http.HttpMethod("GET");
            request.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

            await AddAuthToHeader(request).ConfigureAwait(false);

            var response = await client
                .SendAsync(request, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                .ConfigureAwait(false);

            try
            {
                var status = (int)response.StatusCode;
                var content = await response.Content.ReadAsStringAsync(cancellationToken);
                if (status == 200)
                    return this.EvaluateResponse<T>(response, content);
                else
                    return this.EvaluateErrorResponse<T>(response, content);
            }
            finally
            {
                response.Dispose();
            }
        }

        private async Task AddAuthToHeader(HttpRequestMessage request)
        {
            var date = DateTime.UtcNow
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:sssssZ")
                .Replace(" ", "T");
            request.Headers.("Date", date);

            var content = (await request?.Content?.ReadAsStringAsync()!) ?? string.Empty;

            using var shaM = SHA512.Create();
            var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(
                this.ApiKey.SecureStringToString().ToUpperInvariant()
                + date
                + Encoding.UTF8.GetString(shaM.ComputeHash(Encoding.UTF8.GetBytes(ApiPassword.SecureStringToString())))
                    .ToUpperInvariant()
                + content.ToUpperInvariant()));
            var signature = Encoding.UTF8.GetString(hash);


            request.Headers.Add("Authorization", signature);
        }

        private async Task<WebCallResult<T>> PostAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var data = JsonConvert.SerializeObject(obj ?? new object());
            var response = await client.PostAsync($"{url}", new StringContent(data, Encoding.UTF8, "application/json"),
                cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintPostApiCalls)
            {
                Console.WriteLine($"POST: {url}\nBody: {data}\nResp: {content}");
            }

            // Return
            return this.EvaluateResponse<T>(response, content);
        }

        private async Task<WebCallResult<T>> PutAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var data = JsonConvert.SerializeObject(obj ?? new object());
            var response = await client.PutAsync($"{url}", new StringContent(data, Encoding.UTF8, "application/json"),
                cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (PrintPutApiCalls)
            {
                Console.WriteLine($"PUT: {url}\nBody: {data}\nResp: {content}");
            }

            // Return
            return this.EvaluateResponse<T>(response, content);
        }

        private async Task<WebCallResult<T>> DeleteAsync<T>(string url, object obj = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = GetHttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{url}");
            var data = JsonConvert.SerializeObject(obj ?? new object());
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            // Return
            return this.EvaluateResponse<T>(response, content);
        }

        private WebCallResult<T> EvaluateResponse<T>(HttpResponseMessage response, string content)
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

        private WebCallResult<T> EvaluateErrorResponse<T>(HttpResponseMessage response, string content)
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
