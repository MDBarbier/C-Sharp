using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path1 = Path.Combine(directory, @"Files\1.txt");
            var path2 = Path.Combine(directory, @"Files\2.txt");
            
            var hash1 = GetChecksum(path1);
            var hash2 = GetChecksum(path2);

            if (hash1.SequenceEqual(hash2))
            {
                Console.WriteLine("hashes equal");
            }
            else
            {
                Console.WriteLine("hashes unequal");
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }

        private static byte[] GetChecksum(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
    }
}
