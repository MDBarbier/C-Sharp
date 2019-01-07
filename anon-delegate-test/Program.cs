using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
delegate void Procedure();


namespace anon_delegate_test
{
    class Program
    {
        static Procedure someProcs = null;

        private static void AddProc()
        {
            int variable = 100;

            someProcs += new Procedure(delegate //adds another anon delegated method to our Delegate
            {
                Console.WriteLine(variable);
            });            
        }

        static void Main()
        {
            someProcs += new Procedure(delegate { Console.WriteLine("test"); }); //This adds the anon delegated method to our Delegate (note it does not execute yet)
            AddProc(); //this calls AddProc method
            someProcs(); //calls our Delegate which actually executes both the anon delegated methods we have previously assigned.
            Console.ReadKey();
        }
    }
}
