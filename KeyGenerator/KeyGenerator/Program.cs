using GeneratorLib;
using System;
using System.Security.Cryptography;
using System.Text;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the KeyGenerator\n\n");

            GenerateAndProcessKeys();

            ControlLogic();

            Console.WriteLine("Execution finished, press any key to exit");
            Console.ReadKey();
        }

        private static void ControlLogic()
        {
            string controlResponse = "y";
            while (controlResponse == "y")
            {
                Console.WriteLine($"\n\nDo you want to generate another key? (y/n)");

                controlResponse = Console.ReadLine();

                if (controlResponse == "y")
                {
                    GenerateAndProcessKeys();
                }
                else
                {
                    Console.WriteLine("Reply not 'y', exiting");
                }
            }
        }

        private static void GenerateAndProcessKeys()
        {
            Guid guid = Guid.NewGuid();
            string input = string.Empty;
            string hash = string.Empty;
            string base64encodedHash = string.Empty;

            Console.WriteLine("Enter a string to use as the base for the key: ");

            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("You have note entered a string, a GUID will be generated and used. \n\n");
                input = guid.ToString();
            }

            hash = GenerationUtilities.ComputeSha256Hash(input);

            base64encodedHash = GenerationUtilities.Base64Encode(hash);

            Console.WriteLine($"Sub id format:         {input.Replace("-", "")}");
            Console.WriteLine($"Base input:            {input}");
            Console.WriteLine($"Hashed input:          {hash}");
            Console.WriteLine($"Base64 encoded hash:   {base64encodedHash}");
        }

        
    }
}
