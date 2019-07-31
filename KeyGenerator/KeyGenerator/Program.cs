using System;
using System.Security.Cryptography;
using System.Text;

namespace KeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();
            string input = string.Empty;
            string hash = string.Empty;
            string base64encodedHash = string.Empty;

            Console.WriteLine("Welcome to the KeyGenerator\n\n");

            Console.WriteLine("Enter a string to use as the base for the key: ");

            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("You have note entered a string, a GUID will be generated and used. \n\n");
                input = guid.ToString();
            }

            hash = ComputeSha256Hash(input);

            base64encodedHash = Base64Encode(hash);

            Console.WriteLine($"Sub id format:         {input.Replace("-","")}");
            Console.WriteLine($"Base input:            {input}");
            Console.WriteLine($"Hashed input:          {hash}");
            Console.WriteLine($"Base64 encoded hash:   {base64encodedHash}");
            Console.ReadKey();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
