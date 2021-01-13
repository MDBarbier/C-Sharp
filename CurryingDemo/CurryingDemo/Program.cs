using System;

namespace CurryingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcoming to Currying in C# demo");

            //Uncurried version
            var result0 = add(1, 3);

            Console.WriteLine($"The result0 is: {result0}");

            //Here we invoke both the inner and outer functions together and receive the ultimate result
            var result1 = curriedAdd(3)(4);

            Console.WriteLine($"The result1 is: {result1}");

            //Here we only supply one argument, and receive the inner function back as the result
            var add5 = curriedAdd(5);

            //Now, we can ivoke the method we got back as many times as we want
            var result2 = add5(5);
            var result3 = add5(1);

            Console.WriteLine($"The results are '{result2}' and '{result3}'");

            /* In this example, we use generic curry methods */
             
            //Define the base function
            Func<int, int, int, int, int> addFourThings = (a, b, c, d) => a + b + c + d;

            //Curry one level and get a method you can reuse
            var curriedAddFourThings = Curry(addFourThings);

            int result4 = curriedAddFourThings(1)(2)(3)(4);  // result4 = 10
            Console.WriteLine($"The result4 is: {result4}");

            //Do it step by step
            var addOne = curriedAddFourThings(1);
            var addOneAndTwo = addOne(2);
            var addOneAndTwoAndThree = addOneAndTwo(3);
            int result5 = addOneAndTwoAndThree(4); // result5 = 10
            Console.WriteLine($"The result5 is: {result5}");
        }

        //This is the basic un-curried version of the func
        internal static Func<int, int, int> add = (x, y) => x + y;

        //Our curried method has one Func wrapped in the other
        internal static Func<int, Func<int, int>> curriedAdd = x => y => x + y;


        internal static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(Func<T1, T2, T3> function)
        {
            return a => b => function(a, b);
        }

        internal static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(Func<T1, T2, T3, T4> function)
        {
            return a => b => c => function(a, b, c);
        }

        internal static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> function)
        {
            return a => b => c => d => function(a, b, c, d);
        }
    }
}
