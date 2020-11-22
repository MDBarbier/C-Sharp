using System;

namespace dotnet5test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dotnetversion = Environment.Version;
            Console.WriteLine($"This app is running on {dotnetversion}");
        }
    }
}
