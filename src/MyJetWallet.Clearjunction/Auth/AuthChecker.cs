using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyJetWallet.ClearJunction.Auth
{
    public class AuthChecker : IDisposable
    {
        public AuthChecker(string apiKey, string apiPassword)
        {
            SetAccessToken(apiKey, apiPassword);
        }

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

        public SecureString ApiPassword { get; set; }

        public SecureString ApiKey { get; set; }

        

        public string GetSignature(string date, string content)
        {
            using var shaM = SHA512.Create();

            var concatenated = this.ApiKey.SecureStringToString().ToUpperInvariant()
                               + date
                               + ToHex(shaM.ComputeHash(Encoding.UTF8.GetBytes(ApiPassword.SecureStringToString())))
                                   .ToUpperInvariant()
                               + content.ToUpperInvariant();

            var hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(concatenated));

            var signature = ToHex(hash);
            return signature;
        }

        public string GetCurrentDate()
        {
            return DateTime.UtcNow
                .ToUniversalTime()
                .ToString("yyyy-MM-ddTHH:mm:ss+00:00")
                .Replace(" ", "T");
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

        public void Dispose()
        {
            ApiPassword?.Dispose();
            ApiKey?.Dispose();
        }
    }
}
