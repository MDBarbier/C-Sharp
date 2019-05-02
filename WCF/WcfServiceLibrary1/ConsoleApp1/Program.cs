using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            var reply = client.GetData(5);

            Console.WriteLine("Reply from web service: " + reply);

            Console.ReadLine();
        }
    }
}
