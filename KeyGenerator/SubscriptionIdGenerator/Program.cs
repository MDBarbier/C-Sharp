using System;
using GeneratorLib;

namespace SubscriptionIdGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the SubscriptionIdGenerator\n\n");

            ControlLogic();

            Console.WriteLine("Execution finished, press any key to exit");
            Console.ReadKey();           
        }

        private static void ControlLogic()
        {
            string controlResponse = "y";
            while (controlResponse == "y")
            {
                Console.WriteLine($"\n\nDo you want to generate another sub id? (y/n)");

                controlResponse = Console.ReadLine();

                if (controlResponse == "y")
                {
                    GenerationUtilities.GenerateSubId();
                }
                else
                {
                    Console.WriteLine("Reply not 'y', exiting");
                }
            }           

        }        
    }
}
