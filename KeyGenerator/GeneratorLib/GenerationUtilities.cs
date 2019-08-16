using System;
using System.Security.Cryptography;
using System.Text;

namespace GeneratorLib
{
    public class GenerationUtilities
    {
        public static string GeneratePassword(int length, bool includeSymbols)
        {
            Random random = new Random();
            string candidate = string.Empty;
            string lowerAlphaCharacters = "abcdefghijklmnopqrstuvwxyz";
            string upperAlphaCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numericCharacters = "0123456789";
            string symbolCharacters = "!£$%^&*(){}[],.?";
            bool numberIncluded = false;
            bool symbolIncluded = includeSymbols ? false : true;
            bool uppercaseIncluded = false;

            StringBuilder result = new StringBuilder(length);

            while (!numberIncluded || !uppercaseIncluded || !symbolIncluded)
            {
                candidate = string.Empty;

                for (int i = 0; i < length; i++)
                {


                    int seed = includeSymbols ? random.Next(4) : random.Next(3);

                    switch (seed)
                    {
                        case 0:
                            //append letter
                            result.Append(lowerAlphaCharacters[random.Next(lowerAlphaCharacters.Length)]);
                            break;
                        case 1:
                            //append letter
                            result.Append(upperAlphaCharacters[random.Next(upperAlphaCharacters.Length)]);
                            uppercaseIncluded = true;
                            break;
                        case 2:
                            //append number
                            result.Append(numericCharacters[random.Next(numericCharacters.Length)]);
                            numberIncluded = true;
                            break;
                        case 3:
                            //appendsymbol
                            result.Append(symbolCharacters[random.Next(symbolCharacters.Length)]);
                            symbolIncluded = true;
                            break;
                    }
                }

                candidate = result.ToString();
            }

            return candidate;
        }

        public static string ComputeSha256Hash(string rawData)
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

        public static void GenerateSubId()
        {
            Guid guid = Guid.NewGuid();

            string output = guid.ToString().Replace("-", "").ToLower();

            Console.WriteLine(output);
        }
    }
}
