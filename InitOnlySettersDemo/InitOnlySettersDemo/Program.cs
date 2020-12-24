using System;

namespace InitOnlySettersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p = new Person() { Age = 38, Name = "Matt Barbier" };
            Console.WriteLine(p.ToString());
            //Output: This person is called Matt Barbier and is 38 years old.

            //p.Name = "John Doe"; //won't compile, as the prop is set to only get and init


        }
    }

    public class Person
    {
        public string Name { get; init; }
        public int Age { get; init; }

        public override string ToString()
        {
            return $"This person is called {Name} and is {Age} years old.";
        }
    }
}
