using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyVaultRead
{
    public static class GetSecrets
    {
        public static string AuthKey { get; private set; }
        public static string ConnectionString { get; private set; }

        public static string StripeSecretKey { get; private set; }
         static GetSecrets()
        {
            var BASE_URI = "https://mdashboard-keys.vault.azure.net/";
            var CLIENT_SECRET = ".3z9-wVpu1_.~GdKR-pqLa-NjJs63ME8qU";
            var CLIENT_ID = "be9a06d7-05cd-462d-9eae-f76b281f6dea";
            var TENANT_ID = "c7d03ef3-8f8f-4e37-89ab-dadca007cee0";

            var client = new SecretClient(new Uri(BASE_URI), new ClientSecretCredential(tenantId: TENANT_ID, clientId: CLIENT_ID, clientSecret: CLIENT_SECRET));

            var authKey = client.GetSecret("AuthKey");

            var connectionString = client.GetSecret("DefaultConnectionString");

            var StripeKey = client.GetSecret("StripeApiKey");

            AuthKey = authKey.Value.Value;
            ConnectionString = connectionString.Value.Value;
            StripeSecretKey = StripeKey.Value.Value;
        }
    }
}
