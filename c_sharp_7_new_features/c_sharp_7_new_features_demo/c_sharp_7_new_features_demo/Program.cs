using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_7_new_features_demo
{
    /// <summary>
    /// The .NET 4.6 version has the C# compiler built into it
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Inline out variables and discards
            DemoOutVariables();

            //Pattern matching
            DemoPatterns();
        }

        private static void DemoPatterns()
        {
            //Is expression with constant pattern and type pattern
            object o = 4;
            PrintStars(o);

            //Switch statement pattern matching
            object someObject = new Circle();
            switch (someObject)
            {
                case Circle c: //variables in the cases are in scope only in that case
                    Console.WriteLine("It's a circle!");
                    break;

                case Square s when (s.Area > 100): //order matters now because you can do things like this!
                    Console.WriteLine("It's a big square!");
                    break;

                case Square s: //if this came before the other one, the big square case could never be reached
                    Console.WriteLine("It's a square!");
                    break;

                default: //default case is always evaluated last
                    break;

                case null: //if you do not specify the null case then they will go to default
                    Console.WriteLine("It's NULL!");
                    break;
            }
        }

        private static void PrintStars(object o)
        {
            if (o is null) return; //constant pattrn "null"
            if (!(o is int i)) return; //type pattern "int i"
            Console.WriteLine(new string('*', i));
        }

        private static void DemoOutVariables()
        {
            //The out variables are not declared in advance, it is all done inline
            var boolOutcome = OutVariables("Hello", "World", out string result, out _); //the second out parameter uses a "discard" to say we don't want it

            Console.WriteLine(result);
        }

        private static bool OutVariables(string first, string second, out string result, out string diag)
        {
            diag = DateTime.Now.ToString();
            result = first + " " + second;
            return true;
        }
    }

    struct Circle
    {

    }

    struct Square
    {
        public int Area { get; set; }
    }

    struct Triangle
    {

    }
}
