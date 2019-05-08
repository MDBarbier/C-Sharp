using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace asyncawait
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await Work(); //if you want to wait for the answer before proceeding you use this syntax
            Work();
            Console.WriteLine("Execution finished");
            Console.ReadLine();
        }

        static async Task Work()
        {
            var aRandomNumber = await LongRunningWork(); //whilst this method waits for the result execution passes back to the calling method for any other synchronous work
            Console.WriteLine("LongRunningWorkDone");            
            Console.WriteLine($"The number is: {aRandomNumber}");
            return;
        }

        static async Task<int> LongRunningWork()
        {
            await Task.Delay(10000); // 10 second delay         
            Random rand = new Random();
            return rand.Next();
        }

        static Task Count()
        {
            int counter = 0;
            for (int i = 0; i < 10_000_000; i++)
            {
                counter++;
            }

            return Task.CompletedTask;
        }

        
    }
}
