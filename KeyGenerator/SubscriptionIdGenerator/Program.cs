using System;

namespace SubscriptionIdGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();

            string output = guid.ToString().Replace("-", "").ToLower();

            Console.WriteLine(output);
        }
    }
}
