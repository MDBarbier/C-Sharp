using System;

namespace KeyVaultTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting KeyVault test app");

            AzureKeyVaultLib.AzureKeyVaultManager akvm = new AzureKeyVaultLib.AzureKeyVaultManager();

            var secret = akvm.GetSecretValue("testSecret1");

            Console.WriteLine($"The secret value is: {secret}");

            var allSecretProps = akvm.GetAllSecretProperties();

            foreach (var secretProps in allSecretProps)
            {
                Console.WriteLine($"Secret name: {secretProps.Name}, created on: {secretProps.CreatedOn}");
            }
        }
    }
}
