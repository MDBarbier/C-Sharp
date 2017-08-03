using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await_test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = AsyncCaller();

            Console.WriteLine("Main thread awaiting key to exit program.");

            t.Wait();
            Console.ReadLine();
        }

        static async Task AsyncCaller()
        {
            Console.WriteLine("Background process initiated.");

            await Task.Run(() => WriteNumbers());

            Console.WriteLine("Background execution finished.");
            Console.ReadLine();
        }

        private static void WriteNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                var calculatedNumber = CalculateNumber();
                Console.WriteLine(calculatedNumber);
            }            
        }

        private static int CalculateNumber()
        {
            Thread.Sleep(2000);
            Random rnd = new Random();
            int randomNumber = rnd.Next();

            return randomNumber;
        }
    }
}
