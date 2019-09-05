using GeneratorLib;
using System;

namespace PasswordGenerator
{
    class Program
    {
        public bool IncludeSymbols { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the PasswordGenerator\n\n");

            ControlLogic(0, null);

            Console.WriteLine("Execution finished, press any key to exit");
            Console.ReadKey();
        }

        private static void ControlLogic(int length, bool? includeSymbols)
        {
            string symbolsReply = "";

            if (length == 0)
            {
                Console.WriteLine($"\n\nEnter a length for your password: ");

                while (int.TryParse(Console.ReadLine(), out length) != true)
                {
                    Console.WriteLine($"\n\nInvalid number entered. Enter a length for your password: ");
                }                
            }

            if (includeSymbols == null)
            {
                Console.WriteLine($"\n\nDo you want to include symbols in your password? (y/n)");

                symbolsReply = Console.ReadLine();

                while (!symbolsReply.Equals("y") && symbolsReply.Equals("Y") && !symbolsReply.Equals("n") && !symbolsReply.Equals("y") && !symbolsReply.Equals(""))
                {
                    Console.WriteLine("\n\nInvalid response, answer (y/n):");
                }

                includeSymbols = symbolsReply.Equals("y") || symbolsReply.Equals("Y");

                if (includeSymbols == null)
                    includeSymbols = false;
            }            

            //set minimum length to 8
            length = length < 8 ? 8 : length;
            
            Console.WriteLine($"\n\nYour password is: \n\n{GenerationUtilities.GeneratePassword(length, (bool)includeSymbols)}");

            string controlResponse = "y";

            Console.WriteLine($"\n\nDo you want to generate another password or the (s)ame password? (y/n/s)");

            controlResponse = Console.ReadLine();

            if (controlResponse == "y")
            {
                ControlLogic(0, null);
            }
            else if (controlResponse == "s")
            {
                ControlLogic(length, includeSymbols);
            }
            else
            {
                Console.WriteLine("Reply not 'y', exiting");
            }

        }

    }
}
