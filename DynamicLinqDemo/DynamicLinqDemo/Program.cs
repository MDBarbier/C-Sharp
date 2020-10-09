using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DynamicLinqDemo
{
    class Program

    {

        static void Main(string[] args)

        {

            List<TestClass> data = new List<TestClass>();

            data.Add(new TestClass() { Age = 50, Name = "Jon" });

            data.Add(new TestClass() { Age = 37, Name = "Zon" });

            data.Add(new TestClass() { Age = 28, Name = "Ron" });

            data.Add(new TestClass() { Age = 85, Name = "Don" });



            var queryable = data.AsQueryable();

            string predicate = "Name == \"Zon\"";

            var results = DoTheThing(queryable, predicate);



            foreach (var result in results)

            {

                Console.WriteLine($"Name: {result.Name}, Age: {result.Age}");

            }

        }



        public static List<TestClass> DoTheThing(IQueryable<TestClass> data, string predicate) => data.Where(predicate).ToList();

    }

    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
