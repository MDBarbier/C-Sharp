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
            ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();

            Parallel.For(0, 10_000_000, i => {
                lock (data)
                {
                    data.Add($"world{i}"); 
                }
            });

            Parallel.ForEach(data, new ParallelOptions { MaxDegreeOfParallelism = 5 }, item => 
            {
                Interlocked.Increment(ref counter); /* this is a thread safe way to increment */

                /* This is the the other way to safely increment the counter:
                 * 
                 * lock (_locker) {
                 *      counter++;
                 * }
                 * 
                 * */

                //counter++; /* this method is non thread safe and will leave the counter with about 0.14% less than the full amount by the end */

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
