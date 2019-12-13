using System;
using System.Linq;

namespace FuncTest
{
    class Program
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        /// A func is a built in delegate which acts like a pointer to a method you can use later
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //The last argument to the func is always the return type, the others are params
            Func<int, int, int> add = Sum;
            int result = add(10, 10);
            Console.WriteLine(result);

            //Here we use an anonymous delegate to avoid having to pre-specify a method
            Func<int> getRandomNumber = delegate ()
            {
                Random rnd = new Random();
                return rnd.Next(1, 100);
            };            
            Console.WriteLine(getRandomNumber());

            //Here we use a lambda to replace the external method
            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);
            Console.WriteLine(getRandomNumber2());            
            Func<int, int, int> Sum2 = (x, y) => x + y;            
            Console.WriteLine(Sum2(100, 55));

            //Action is the same as func except it returns no value
            Action<int> printActionDel = delegate (int i)
            {
                Console.WriteLine(i);
            };
            printActionDel(9999);

            //Using a Func and a lambda 
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));
            // Output:
            // 25


            /*This example shows the difference in syntax between using a delegate and using lambdas */
            // anonymous delegate
            var evens1 = Enumerable
                .Range(1, 100)
                .Where(delegate (int x) { return (x % 2) == 0; })
                .ToList();

            // lambda expression
            var evens2 = Enumerable
                .Range(1, 100)
                .Where(x => (x % 2) == 0)
                .ToList();
        }
    }
}
