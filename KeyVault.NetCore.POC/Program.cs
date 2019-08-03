using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace KeyVault.NetCore.POC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((ctx, builder) =>
               {
                   var keyVaultEndpoint = GetKeyVaultEndpoint();
                   if (!string.IsNullOrEmpty(keyVaultEndpoint))
                   {
					   //var azureServiceTokenProvider = new AzureServiceTokenProvider();
					   //var keyVaultClient = new KeyVaultClient(
					   //    new KeyVaultClient.AuthenticationCallback(
					   //        azureServiceTokenProvider.KeyVaultTokenCallback));
					   //builder.AddAzureKeyVault(
					   //    keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
					   //string secretUrl = "https://<your key vault name>.vault.azure.net/secrets/<your key name>";
					   //var secretWeJustWroteTo = keyVaultClient.GetSecretAsync(secretUrl).Result;
					   var config = builder.Build();
					   var azureKeyVaultUrl = "https://<your key vault name>.vault.azure.net";
					   if (!string.IsNullOrWhiteSpace(azureKeyVaultUrl))
					   {
						   builder.AddAzureKeyVault(azureKeyVaultUrl);
					   }
				   }
               }
            ).UseStartup<Startup>()
             .Build();

        private static string GetKeyVaultEndpoint() => "<your key vault name>.vault.azure.net";
    }
}
