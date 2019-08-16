using GeneratorLib;
using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the PasswordGenerator\n\n");

            ControlLogic();

            Console.WriteLine("Execution finished, press any key to exit");
            Console.ReadKey();
        }

        private static void ControlLogic()
        {
            bool includeSymbols = true;
            int length = 0;

            Console.WriteLine($"\n\nEnter a length for your password: ");

            while (int.TryParse(Console.ReadLine(), out length) != true)
            {
                Console.WriteLine($"\n\nInvalid number entered. Enter a length for your password: ");
            }

            Console.WriteLine($"\n\nDo you want to include symbols in your password? (y/n)");

            var symbolsReply = Console.ReadLine();

            while (!symbolsReply.Equals("y") && symbolsReply.Equals("Y") && !symbolsReply.Equals("n") && !symbolsReply.Equals("y") && !symbolsReply.Equals(""))
            {
                Console.WriteLine("\n\nInvalid response, answer (y/n):");
            }

            includeSymbols = symbolsReply.Equals("y") || symbolsReply.Equals("Y") || symbolsReply.Equals("") ? true : false;

            //set minimum length to 8
            length = length < 8 ? 8 : length;

            Console.WriteLine($"\n\nYour password is: \n\n{GenerationUtilities.GeneratePassword(length, includeSymbols)}");

            string controlResponse = "y";
            while (controlResponse == "y")
            {
                Console.WriteLine($"\n\nDo you want to generate another password? (y/n)");

                controlResponse = Console.ReadLine();

                if (controlResponse == "y")
                {
                    ControlLogic();
                }
                else
                {
                    Console.WriteLine("Reply not 'y', exiting");
                }
            }
        }       
        
    }
}
