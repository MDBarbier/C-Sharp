using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalJsonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            JObject json = new JObject();
            string data = "{\"person\": { \"name\": \"matt\", \"age\":\"37\"}}";
            json = JObject.Parse(data);
            string address = string.Empty;
            string name = string.Empty;

            //This will throw an error
            try
            {
                //The second level property does not exist
                address = json["person"]["address"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error trying to access the property: " + ex.Message);
            }

            try
            {
                name = json["person"]["name"].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error trying to access the property: " + ex.Message);
            }

            //This will not fire an exception event though the second level prop doesn't exist
            address = json["person"]["address"]?.ToString();

            //This will not fire an exception even though the top level prop does not exist
            name = json["person2"]?["name"]?.ToString();

            Console.WriteLine("The value of name was: " + name);
            Console.WriteLine("The value of address was: " + address);
            Console.WriteLine("Execution complete");
            Console.ReadLine();
        }
    }
}
