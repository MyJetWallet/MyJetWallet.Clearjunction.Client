using System;
using System.Text.Json;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction;

namespace TestApp
{
    static class Program
    {
        private static string _accessToken;

        static async Task Main(string[] args)
        {
            //_accessToken = Environment.GetEnvironmentVariable("CircleAccessToken");

            //if (string.IsNullOrEmpty(_accessToken))
            //{
            //    Console.WriteLine("AccessToken is empty. Please setup env variable");
            //    return;
            //}

           

            var response = await client.GetAsync<string>("v7/gate/allocate/v2/info/iban/GB00CLJU00000011111111");

            //await TestPayouts();
            // await TestPublicKey();
            //await TestCards();
            //await TestBankAccounts();
        }
    }
}
