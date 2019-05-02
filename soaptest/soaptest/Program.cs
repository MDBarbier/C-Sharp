using ServiceReference1;
using System;
using System.Threading.Tasks;

namespace soaptest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CalculatorSoapClient soapClient = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);

            var message = System.Configuration.ConfigurationManager.AppSettings["test"];

            var answer = await soapClient.AddAsync(5, 5);

            Console.WriteLine("The answer is: " + answer);
        }
    }
}
