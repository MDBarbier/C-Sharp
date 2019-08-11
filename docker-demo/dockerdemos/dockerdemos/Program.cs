using System;

namespace dockerdemos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! This app is running in a docker container on the {Environment.OSVersion} operating system");
        }
    }
}
