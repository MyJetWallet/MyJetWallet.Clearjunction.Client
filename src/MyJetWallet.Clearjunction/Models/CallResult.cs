using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace MyJetWallet.ClearJunction.Models
{
    public class CallResult<T>
    {
        /// <summary>
        /// The data returned by the call
        /// </summary>
        public T Data { get; internal set; }

        /// <summary>
        /// An error code if the call didn't succeed
        /// </summary>
        public int Code { get; internal set; }

        /// <summary>
        /// Whether the call was successful
        /// </summary>
        public bool Success =>
            Code is (int)HttpStatusCode.OK or (int)HttpStatusCode.Created or (int)HttpStatusCode.Accepted;

        public ClearJunctionError Error { get; set; }

        public CallResult(T data, int code, ClearJunctionError? error)
        {
            Data = data;
            Code = code;
            Error = error;
        }
    }

    public class WebCallResult<T> : CallResult<T>
    {
        /// <summary>
        /// The status code of the response. Note that a OK status does not always indicate success, check the Success parameter for this.
        /// </summary>
        public HttpStatusCode? ResponseStatusCode { get; set; }

        public Dictionary<string, string> ResponseHeaders { get; set; }

        public WebCallResult(HttpResponseMessage response, T data, HttpStatusCode code, ClearJunctionError? error) : base(data,
            (int)code, error)
        {
            if (response == null) return;
            ResponseStatusCode = response?.StatusCode;
            ResponseHeaders = new Dictionary<string, string>();
            foreach (var header in response.Headers)
            {
                ResponseHeaders.Add(header.Key, string.Join(";", header.Value));
            }
        }

        public WebCallResult(HttpResponseMessage response, CallResult<T> result) : base(result.Data,
            (int)response.StatusCode,
            result.Error)
        {
            ResponseStatusCode = response.StatusCode;
            ResponseHeaders = new Dictionary<string, string>();
            foreach (var header in response.Headers)
            {
                ResponseHeaders.Add(header.Key, string.Join(";", header.Value));
            }
        }
    }
}
