using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parallel_foreach_test
{
    class Program
    {
        static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            sw.Start();
            List<string> data = new List<string>();
            List<string> finalData = new List<string>();
            int counter = 0;

            Parallel.For(0, 10_000_000, i => {
                lock (data)
                {
                    data.Add($"world{i}"); 
                }
            });

            Parallel.ForEach(data, new ParallelOptions { MaxDegreeOfParallelism = 5 }, item => 
            {
                //Interlocked.Increment(ref counter);                
                counter++;

                lock (finalData)
                {
                    finalData.Add(AppendData(item)); 
                }
            });

            sw.Stop();
            Console.WriteLine("Final data contains " + finalData.Count + " items");
            Console.WriteLine("Counter contains " + counter);
            Console.WriteLine("Execution finished in " + sw.Elapsed);
            
            Console.ReadLine();
        }

        private static string AppendData(string item)
        {
            return "hello " + item;
        }
    }
}
