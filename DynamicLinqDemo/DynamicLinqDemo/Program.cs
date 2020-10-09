using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace DynamicLinqDemo
{
    class Program

    {

        static void Main()

        {
            List<TestClass> data = FillTestData();

            var queryable = data.AsQueryable();

            string predicate = "Name == \"Zon\" && Age == 37";

            var results = queryable.Where(predicate).ToList();

            foreach (var result in results)
            {
                Console.WriteLine($"Name: {result.Name}, Age: {result.Age}");
            }
        }

        private static List<TestClass> FillTestData()
        {
            List<TestClass> data = new List<TestClass>();

            data.Add(new TestClass() { Age = 50, Name = "Jon" });
            data.Add(new TestClass() { Age = 37, Name = "Zon" });
            data.Add(new TestClass() { Age = 28, Name = "Ron" });
            data.Add(new TestClass() { Age = 85, Name = "Don" });
            return data;
        }
    }

    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
