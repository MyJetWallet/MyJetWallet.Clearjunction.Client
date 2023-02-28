using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction;
using MyJetWallet.ClearJunction.Models.RequisitesAllocation;
using Newtonsoft.Json;

namespace TestApp
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var client = new ClearJunctionClient("", "", "");

            //var response = await client.GetAsync<string>("v7/gate/allocate/v2/info/iban/GB00CLJU00000011111111");


            //var response1 = await client.PostAsync<string>("v7/gate/wallets/statement",
            //    new RequestX
            //    {
            //        walletUuid = "988382de-18a9-46ec-a25d-41b274fe2bc3",
            //        dateFrom = "2023-02-21",
            //        dateTo = "2023-02-23"
            //    });

            var clientOrder = "999899-0009";
            var ser =
                $"{{  \"clientOrder\": \"{clientOrder}\",  \"postbackUrl\": \"https://webhook-uat.simple-spot.biz/clearjunction/webhook\",  \"walletUuid\": \"988382de-18a9-46ec-a25d-41b274fe2bc3\",  \"ibansGroup\": \"DEFAULT\",  \"ibanCountry\": \"GB\",  \"registrant\": {{    \"clientCustomerId\": \"2983ght938\",    \"individual\": {{      \"phone\": \"34712345678\",      \"email\": \"peterson.julie@example.com\",      \"birthDate\": \"1999-09-29\",      \"birthPlace\": \"'Madrid, Spain'\",      \"address\": {{        \"country\": \"IT\",        \"zip\": \"123455\",        \"city\": \"Rome\",        \"street\": \"12 Tourin\"      }},      \"document\": {{        \"type\": \"passport\",        \"number\": \"AB1000222\",        \"issuedCountryCode\": \"IT\",        \"issuedBy\": \"Ministry of Interior\",        \"issuedDate\": \"2016-12-21\",        \"expirationDate\": \"2026-12-20\"      }},      \"lastName\": \"Peterson\",      \"firstName\": \"Julie\",      \"middleName\": \"Maria\"    }}  }},  \"customInfo\": {{    \"MyExampleParam1\": \"exampleValue1\",    \"MyExampleObject1\": {{      \"MyExampleParam2\": \"exampleValue2\",      \"MyExampleParam3\": \"exampleValue3\"    }}  }}}}";

            var request = JsonConvert.DeserializeObject<RequestAllocation>(ser);

            //var list = await client.GetIbanListByClientCustomerIdAsync("2983ght938");
            //var createIban = await client.CreateIbanAsync(request);
            var ibanOrder = await client.GetIbanByClientOrderAsync(clientOrder);
            var ibanreference = await client.GetIbanByOrderReferenceAsync(ibanOrder.Data.OrderReference);
            var ibanInfo = await client.GetIbanInfoAsync(ibanOrder.Data.Iban);
            

            //var response2 = await client.GetStatementAsync("988382de-18a9-46ec-a25d-41b274fe2bc3",
            //    new DateTime(2023, 2, 21),
            //    new DateTime(2023, 2, 23));
        }
    }

    public class RequestX
    {
        public string walletUuid { get; set; }

        public string dateFrom { get; set; }

        public string dateTo { get; set; }
    }
}
