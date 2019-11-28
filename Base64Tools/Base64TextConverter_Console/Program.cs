using System;
using System.Text;

namespace Base64TextConverter_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paste the base64:");

            var b64 = Console.ReadLine();

            var decoded = DecodeBase64(b64);

            Console.WriteLine(decoded);
        }

        public static string DecodeBase64(string base64encoded)
        {
            string base64Decoded;
            byte[] data = Convert.FromBase64String(base64encoded);
            base64Decoded = ASCIIEncoding.ASCII.GetString(data);
            return base64Decoded;
        }
    }
}
