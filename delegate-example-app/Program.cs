using System;
using System.Collections.Generic;

namespace delegate_example_app
{

    /// <summary>
    /// A class to define a person
    /// </summary>
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        //Our delegate
        public delegate bool FilterDelegate(Person p);

        private static void Main()
        {

            //Create 4 Person objects
            var p1 = new Person() { Name = "John", Age = 41 };
            var p2 = new Person() { Name = "Jane", Age = 69 };
            var p3 = new Person() { Name = "Jake", Age = 12 };
            var p4 = new Person() { Name = "Jessie", Age = 25 };

            //Create a list of Person objects and fill it
            var people = new List<Person>() { p1, p2, p3, p4 };

            //Invoke DisplayPeople using appropriate delegate
            DisplayPeople("Children:", people, IsChild);
            DisplayPeople("Adults:", people, IsAdult);
            DisplayPeople("Seniors:", people, IsSenior);

            Console.Read();
        }

        /// <summary>
        /// A method to filter out the people you need
        /// </summary>
        /// <param name="people">A list of people</param>
        /// <param name="filter">A filter</param>
        /// <param name="title">Text to display></param>
        /// <returns>A filtered list</returns>
        private static void DisplayPeople(string title, IEnumerable<Person> people, FilterDelegate filter)
        {
            Console.WriteLine(title);

            foreach (var p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }

        //==========FILTERS===================
        private static bool IsChild(Person p)
        {
            return p.Age < 18;
        }

        private static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        private static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }
    }
}
