using System;
using System.Threading.Tasks;
using MyJetWallet.ClearJunction;
using Newtonsoft.Json;

namespace TestApp;

static class Program
{
    static async Task Main(string[] args)
    {
        // var order = Guid.NewGuid().ToString("N");
        var client = new ClearJunctionClient(
            Environment.GetEnvironmentVariable("ApiKey"),
            Environment.GetEnvironmentVariable("ApiPassword"),
            Environment.GetEnvironmentVariable("ApiPasswordRootUrl"));

        // var approvePayouts = await client.ApprovePayoutAsync(
        //     new OrderReferences
        //     {
        //         Orders = new string[]
        //         {
        //             "98fbff91-25ac-4797-bd8c-b8d58b624fcd",
        //             "98fbff95-63f9-4d3e-a9b1-88a3762873f8",
        //             "98fbff96-3e25-44f6-86fa-2e5ee7338c8b",
        //             "98fbff97-3843-4ade-a766-6a21404b1f47",
        //             "98fbff98-bddb-4d2b-a2a1-83de4478b2a9",
        //         }
        //     });

        var checkSepaIban = await client.CheckRequisiteAsync("LV97HABA0012345678910");
            
        Console.WriteLine(checkSepaIban.ResponseStatusCode);
        Console.WriteLine(JsonConvert.SerializeObject(checkSepaIban.Data));
            
            
        //var checkSepaIban = await client.CheckRequisiteAsync("GBXXCLJU04130780084180");
        //var checkSepaIban = await client.CheckRequisiteAsync("GBXXCLJU04130780079590");


        // var payout = "{\"clientOrder\":\""+ order + "\"," +
        //              //"{\"clientOrder\":\"17db041984ca4e6ea561500021a3a650\"," +
        //              "\"currency\":\"EUR\",\"amount\":100.0," +
        //              "\"description\":\"Test payout 25b7b2f76ff94c24be2bfa3710015adf\"," +
        //              "\"postbackUrl\":\"https://webhook-uat.simple-spot.biz/clearjunction/webhook/payout\"," +
        //              "\"payer\":{\"clientCustomerId\":\"37e49e3565094b67830f6b3f34e3d67f\"," +
        //              "\"walletUuid\":\"988382de-18a9-46ec-a25d-41b274fe2bc3\"," +
        //              "\"individual\":{\"lastName\":\"Pliaskin\",\"firstName\":\"Iurii\"}}," +
        //              "\"payee\":{\"individual\":{\"lastName\":\"Pliaskin\",\"firstName\":\"Iurii\"}}," +
        //              //"\"payeeRequisite\":{\"iban\":\"GBXXCLJU04130780084187\",\"bankSwiftCode\":null, }," +
        //              //"\"payerRequisite\":{\"iban\":\"GBXXCLJU04130780079590\",\"bankSwiftCode\":null, \"name\":\"Simple Europe UAB\"}}";
        //               "\"payeeRequisite\":{\"iban\":\"LT933250066755815010\",\"bankSwiftCode\":\"REVOLT21\"}," +
        //               "\"payerRequisite\":{\"iban\":\"GBXXCLJU04130780079590\",\"bankSwiftCode\":null}}";
        // var payout = "{\"clientOrder\":\"f99a29b6-6426-4a92-81ef-05f53229c1eb:\",\"currency\":\"EUR\",\"amount\":100.0,\"description\":\"Sent from Simple.App\",\"postbackUrl\":\"https://webhook-uat.simple-spot.biz/clearjunction/webhook/payout\",\"payer\":{\"clientCustomerId\":\"8a3d35230b15403faeec4e4a671f9c67\",\"walletUuid\":\"988382de-18a9-46ec-a25d-41b274fe2bc3\",\"individual\":{\"lastName\":\"Krasnianska\",\"firstName\":\"Alina\"}},\"payee\":{\"individual\":{\"lastName\":\"Krasnianska\",\"firstName\":\"Alina\"}},\"payeeRequisite\":{\"iban\":\"GBXXCLJU04130780084187\",\"bankSwiftCode\":\"CLJUGB21XXX\",\"name\":\"Clear Junction Limited\"},\"payerRequisite\":{\"iban\":\"GBXXCLJU04130780085122\",\"bankSwiftCode\":\"CLJUGB21XXX\",\"name\":\"Simple Europe UAB\"}}";
        // var payoutRequest = JsonConvert.DeserializeObject<SepaInstantPayout>(payout);
        // var createPayout = await client.ExecuteSepaInstantPayoutAsync(payoutRequest);
        // while (true && createPayout.Success)
        // {
        //     var getStatusResponse = await client.GetPayoutStatusByOrderReferenceAsync(createPayout?.Data?.OrderReference);
        //     if (!getStatusResponse.Success)
        //     {
        //         Console.WriteLine(getStatusResponse.Error.Errors[0].Message);
        //         break;
        //     }
        //
        //     switch (getStatusResponse.Data.Status)
        //     {
        //         case PayoutNotificationStatus.Pending:
        //             Console.WriteLine("Payout Pending");
        //             break;
        //         case PayoutNotificationStatus.Created:
        //             var approvePayout = await client.ApprovePayoutAsync(
        //                 new OrderReferences
        //                 {
        //                     Orders = new string[]
        //                     {
        //                         createPayout.Data.RequestReference,
        //                     }
        //                 });
        //             Console.WriteLine("Payout Created");
        //             break;
        //         case PayoutNotificationStatus.Settled:
        //             Console.WriteLine("Payout Settled");
        //             break;
        //         case PayoutNotificationStatus.Canceled:
        //             Console.WriteLine("Payout Canceled");
        //             break;
        //         case PayoutNotificationStatus.Declined:
        //             Console.WriteLine("Payout Declined");
        //             break;
        //     }
        //     if (getStatusResponse.Data.Status == PayoutNotificationStatus.Settled)
        //     {
        //         Console.WriteLine("Payout completed");
        //         break;
        //     }
        //     Thread.Sleep(10000);
        // }
        //
        // //var response = await client.GetAsync<string>("v7/gate/allocate/v2/info/iban/GB00CLJU00000011111111");
        //
        //
        // //var response1 = await client.PostAsync<string>("v7/gate/wallets/statement",
        // //    new RequestX
        // //    {
        // //        walletUuid = "988382de-18a9-46ec-a25d-41b274fe2bc3",
        // //        dateFrom = "2023-02-21",
        // //        dateTo = "2023-02-23"
        // //    });
        //
        // var clientOrder = "999899-0009";
        // var ser =
        //     $"{{  \"clientOrder\": \"{clientOrder}\",  \"postbackUrl\": \"https://webhook-uat.simple-spot.biz/clearjunction/webhook\",  \"walletUuid\": \"988382de-18a9-46ec-a25d-41b274fe2bc3\",  \"ibansGroup\": \"DEFAULT\",  \"ibanCountry\": \"GB\",  \"registrant\": {{    \"clientCustomerId\": \"2983ght938\",    \"individual\": {{      \"phone\": \"34712345678\",      \"email\": \"peterson.julie@example.com\",      \"birthDate\": \"1999-09-29\",      \"birthPlace\": \"'Madrid, Spain'\",      \"address\": {{        \"country\": \"IT\",        \"zip\": \"123455\",        \"city\": \"Rome\",        \"street\": \"12 Tourin\"      }},      \"document\": {{        \"type\": \"passport\",        \"number\": \"AB1000222\",        \"issuedCountryCode\": \"IT\",        \"issuedBy\": \"Ministry of Interior\",        \"issuedDate\": \"2016-12-21\",        \"expirationDate\": \"2026-12-20\"      }},      \"lastName\": \"Peterson\",      \"firstName\": \"Julie\",      \"middleName\": \"Maria\"    }}  }},  \"customInfo\": {{    \"MyExampleParam1\": \"exampleValue1\",    \"MyExampleObject1\": {{      \"MyExampleParam2\": \"exampleValue2\",      \"MyExampleParam3\": \"exampleValue3\"    }}  }}}}";
        //
        // var request = JsonConvert.DeserializeObject<RequestAllocation>(ser);
        //
        // //var list = await client.GetIbanListByClientCustomerIdAsync("2983ght938");
        // //var createIban = await client.CreateIbanAsync(request);
        // var ibanOrder = await client.GetIbanByClientOrderAsync(clientOrder);
        // var ibanreference = await client.GetIbanByOrderReferenceAsync(ibanOrder.Data.OrderReference);
        // var ibanInfo = await client.GetIbanInfoAsync(ibanOrder.Data.Iban);


        ClearJunctionClient.PrintPostApiCalls = true;

        var response2 = await client.GetReportsAsync("",
            new DateTime(2024, 1, 12),
            new DateTime(2024, 1, 18));

        Console.WriteLine(response2.ResponseStatusCode);
    }
}