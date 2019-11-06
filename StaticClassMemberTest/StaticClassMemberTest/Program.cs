using System;

namespace StaticClassMemberTest
{
    /// <summary>
    /// This program demonstrates using a static property to keep track of some value class wide, and using static methods.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person.OutputPeopleCreated();

            Person p1 = new Person();
            Person p2 = new Person("Matt Barbier", "21 Some Road", 37);

            Person.OutputPeopleCreated();

            Console.WriteLine("Execution finished");
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public static int NumberPeopleCreated { get; set; } = 0;

        public Person()
        {
            NumberPeopleCreated++;
        }

        public Person(string Name, string Address, int Age)
        {
            this.Age = Age;
            this.Name = Name;
            this.Address = Address;

            NumberPeopleCreated++;
        }

        internal static void OutputPeopleCreated()
        {
            Console.WriteLine($"There have been {Person.NumberPeopleCreated} people created so far");
        }
    }
}
