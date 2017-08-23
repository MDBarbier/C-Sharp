using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string userSentance = string.Empty;
            int totalWords = 0;
            int totalCharWithoutSpace = 0;
            Console.WriteLine("Enter a sentance:");
            userSentance = Console.ReadLine();

            //calling Extension Method WordCount
            totalWords = userSentance.WordCount();
            Console.WriteLine("Total number of words in the sentance you entered is: " + totalWords);

            //calling Extension Method to count character
            totalCharWithoutSpace = userSentance.TotalCharWithoutSpace();

            Console.WriteLine("Total number of characters without spaces in that sentance is: " + totalCharWithoutSpace);

            Console.WriteLine("Execution finished.");
            Console.ReadKey();
        }
    }
}
