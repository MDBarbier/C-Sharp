using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQuery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<string> fruits = new List<string>()
            {
                "Apple",
                "Orange",
                "Pineapple",
                "Star",
                "Melon",
                "Banana"
            };

            BasicQuery(fruits);
            MethodSyntaxQuery(fruits);
        }

        private static void BasicQuery(IEnumerable<string> fruits)
        {
            // Define the query using query syntax
            var fruitQuery =
                from fruit in fruits
                where fruit.Contains('a')
                select fruit;

            // Execute the query
            foreach (var i in fruitQuery)
            {
                Console.Write(i + " ");
            }            
        }

        private static void MethodSyntaxQuery(IEnumerable<string> fruits)
        {
            //Define a query using method syntax
            var orderedFruits = fruits.Where(fruit => fruit.Contains('a')).OrderBy(fruit => fruit);

            Console.WriteLine();

            // Execute the query.
            foreach (var i in orderedFruits)
            {
                Console.Write(i + " ");
            }
        }
    }
}
