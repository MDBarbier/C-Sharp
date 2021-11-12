using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace RecursionPassByRefTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            for (int i = 0; i < 5000; i++)
            {
                JArray compositeDataArray = new JArray();
                await GetData1(compositeDataArray);
                await GetData2(compositeDataArray);
                await GetData3(compositeDataArray);
                await GetData4(compositeDataArray);

                var validationResult = Validate(compositeDataArray);

                if (!validationResult)
                {
                    Console.WriteLine($"Iteration {i} finished, Validation result: {validationResult}");  
                }
                else
                {
                    Console.Write($"{i},");
                }
            }

            Console.WriteLine("Execution finished");
        }

        private static bool Validate(JArray compositeDataArray)
        {
            bool success = true;

            if (compositeDataArray[0]["name"].ToString() != "a")
            {
                Console.WriteLine("'a' not in expected position!");
                success = false;
            }
            if (compositeDataArray[1]["name"].ToString() != "b")
            {
                Console.WriteLine("'b' not in expected position!");
                success = false;
            }
            if (compositeDataArray[2]["name"].ToString() != "c")
            {
                Console.WriteLine("'c' not in expected position!");
                success = false;
            }
            if (compositeDataArray[3]["name"].ToString() != "d")
            {
                Console.WriteLine("'d' not in expected position!");
                success = false;
            }
            if (compositeDataArray[4]["name"].ToString() != "e")
            {
                Console.WriteLine("'e' not in expected position!");
                success = false;
            }
            if (compositeDataArray[5]["name"].ToString() != "f")
            {
                Console.WriteLine("'f' not in expected position!");
                success = false;
            }
            if (compositeDataArray[6]["name"].ToString() != "g")
            {
                Console.WriteLine("'g' not in expected position!");
                success = false;
            }
            if (compositeDataArray[7]["name"].ToString() != "h")
            {
                Console.WriteLine("'h' not in expected position!");
                success = false;
            }
            if (compositeDataArray[8]["name"].ToString() != "i")
            {
                Console.WriteLine("'i' not in expected position!");
                success = false;
            }
            if (compositeDataArray[9]["name"].ToString() != "j")
            {
                Console.WriteLine("'j' not in expected position!");
                success = false;
            }
            if (compositeDataArray[10]["name"].ToString() != "k")
            {
                Console.WriteLine("'k' not in expected position!");
                success = false;
            }
            if (compositeDataArray[11]["name"].ToString() != "l")
            {
                Console.WriteLine("'l' not in expected position!");
                success = false;
            }
            if (compositeDataArray[12]["name"].ToString() != "m")
            {
                Console.WriteLine("'m' not in expected position!");
                success = false;
            }
            if (compositeDataArray[13]["name"].ToString() != "n")
            {
                Console.WriteLine("'n' not in expected position!");
                success = false;
            }
            if (compositeDataArray[14]["name"].ToString() != "o")
            {
                Console.WriteLine("'o' not in expected position!");
                success = false;
            }
            if (compositeDataArray[15]["name"].ToString() != "p")
            {
                Console.WriteLine("'p' not in expected position!");
                success = false;
            }
            if (compositeDataArray[16]["name"].ToString() != "q")
            {
                Console.WriteLine("'q' not in expected position!");
                success = false;
            }
            if (compositeDataArray[17]["name"].ToString() != "r")
            {
                Console.WriteLine("'r' not in expected position!");
                success = false;
            }
            if (compositeDataArray[18]["name"].ToString() != "s")
            {
                Console.WriteLine("'s' not in expected position!");
                success = false;
            }
            if (compositeDataArray[19]["name"].ToString() != "t")
            {
                Console.WriteLine("'t' not in expected position!");
                success = false;
            }
            if (compositeDataArray[20]["name"].ToString() != "u")
            {
                Console.WriteLine("'u' not in expected position!");
                success = false;
            }
            if (compositeDataArray[21]["name"].ToString() != "v")
            {
                Console.WriteLine("'v' not in expected position!");
                success = false;
            }
            if (compositeDataArray[22]["name"].ToString() != "w")
            {
                Console.WriteLine("'w' not in expected position!");
                success = false;
            }
            if (compositeDataArray[23]["name"].ToString() != "x")
            {
                Console.WriteLine("'x' not in expected position!");
                success = false;
            }
            if (compositeDataArray[24]["name"].ToString() != "y")
            {
                Console.WriteLine("'y' not in expected position!");
                success = false;
            }
            if (compositeDataArray[25]["name"].ToString() != "z")
            {
                Console.WriteLine("'z' not in expected position!");
                success = false;
            }

            return success;
        }

        private static async Task GetData1(JArray compositeArray)
        {
            await Task.Delay(1);
            JArray data = new();
            data.Add(new JObject() { { "name", "a" } });
            data.Add(new JObject() { { "name", "b" } });
            data.Add(new JObject() { { "name", "c" } });
            data.Add(new JObject() { { "name", "d" } });
            data.Add(new JObject() { { "name", "e" } });
            data.Add(new JObject() { { "name", "f" } });
            data.Add(new JObject() { { "name", "g" } });
            compositeArray.Merge(data);
        }

        private static async Task GetData2(JArray compositeArray)
        {
            await Task.Delay(1);
            JArray data = new();
            data.Add(new JObject() { { "name", "h" } });
            data.Add(new JObject() { { "name", "i" } });
            data.Add(new JObject() { { "name", "j" } });
            data.Add(new JObject() { { "name", "k" } });
            data.Add(new JObject() { { "name", "l" } });
            data.Add(new JObject() { { "name", "m" } });
            data.Add(new JObject() { { "name", "n" } });
            compositeArray.Merge(data);
        }
        private static async Task GetData3(JArray compositeArray)
        {
            await Task.Delay(1);
            JArray data = new();
            data.Add(new JObject() { { "name", "o" } });
            data.Add(new JObject() { { "name", "p" } });
            data.Add(new JObject() { { "name", "q" } });
            data.Add(new JObject() { { "name", "r" } });
            data.Add(new JObject() { { "name", "s" } });
            data.Add(new JObject() { { "name", "t" } });
            data.Add(new JObject() { { "name", "u" } });
            compositeArray.Merge(data);
        }
        private static async Task GetData4(JArray compositeArray)
        {
            await Task.Delay(1);
            JArray data = new();
            data.Add(new JObject() { { "name", "v" } });
            data.Add(new JObject() { { "name", "w" } });
            data.Add(new JObject() { { "name", "x" } });
            data.Add(new JObject() { { "name", "y" } });
            data.Add(new JObject() { { "name", "z" } });
            compositeArray.Merge(data);
        }
    }
}
