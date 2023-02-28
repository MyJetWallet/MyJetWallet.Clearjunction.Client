using System;
using System.Net;

namespace MyJetWallet.ClearJunction
{
    public class ClearJunctionException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public string ErrorMessage { get; set; }

        public ClearJunctionException(HttpStatusCode code, string errorMessage) : base(
            $"Error response from ClearJunction: [{code}] {errorMessage}")
        {
            Code = code;
            ErrorMessage = errorMessage;
        }
    }
}
