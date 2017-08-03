using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_await_io_bound
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Task w = AsyncCaller();

            Console.WriteLine("Main thread awaiting key to exit program.");

            w.Wait();
            Console.ReadLine();
        }

        //This method is a wrapper to get around the fact that Main cannot be async
        static async Task AsyncCaller() 
        {
            Console.WriteLine("Background process initiated.");

            var length = await GetWebPageHtmlSizeAsync(); //the await keyword means execution will halt here until this method is complete

            Console.WriteLine("Background execution finished. Length of reply: " + length);
            Console.ReadLine();
        }

        //this method is async and returns asynchronously an integer which the Await keyword on the method call "unwraps"
        private static async Task<int> GetWebPageHtmlSizeAsync()
        {
            var client = new HttpClient();
            var html = await client.GetAsync("https://en.wikipedia.org/w/api.php?action=query&titles=Main%20Page&prop=revisions&rvprop=content&format=json");
            //await Task.Delay(5000);
            var y = await html.Content.ReadAsStringAsync(); //here again the await keyword "unwraps" the Task<string> returned by ReadAsStringAsync()
            
            return y.Length;
        }
    }
}
