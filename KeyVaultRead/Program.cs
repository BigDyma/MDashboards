using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;

namespace KeyVaultRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var BASE_URI = "https://mdashboard-keys.vault.azure.net/";
            var CLIENT_SECRET = ".3z9-wVpu1_.~GdKR-pqLa-NjJs63ME8qU";
            var CLIENT_ID = "be9a06d7-05cd-462d-9eae-f76b281f6dea";
            var TENANT_ID = "c7d03ef3-8f8f-4e37-89ab-dadca007cee0";

            var client = new SecretClient(new Uri(BASE_URI), new ClientSecretCredential(tenantId: TENANT_ID, clientId: CLIENT_ID, clientSecret: CLIENT_SECRET));

            var authKey = client.GetSecret("AuthKey");

            var connectionString = client.GetSecret("ConnectionString");

            Console.WriteLine(authKey);
        }
    }
}
