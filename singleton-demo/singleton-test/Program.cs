using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                singleton_test.Singleton i = singleton_test.Singleton.Instance;
                singleton_test.Singleton j = singleton_test.Singleton.Instance;

                Console.WriteLine($"initial i message: { i.Message}, initial j message: {j.Message}");

                j.Message = "Bye world!";

                Console.WriteLine("Setting message via j reference...");
                Console.WriteLine($"updated i message: { i.Message}, updated j message: {j.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Singleton creartion failed: " + ex.Message);                
            }

            Console.ReadLine();
        }
    }
}
