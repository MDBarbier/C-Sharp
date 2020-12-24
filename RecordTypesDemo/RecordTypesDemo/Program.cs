using System;

namespace RecordTypesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p1 = new Person("matt", "barbier");
            //p1.FirstName = "dave"; //This will not compile because the property is read only
            Person p2 = new Person("dave", "barbier");
            Person p3 = new Person("matt", "barbier");

            if (p1.Equals(p2))
            {
                Console.WriteLine("p1 is equal to p2");
            }
            else
            {
                Console.WriteLine("p1 isn't equal to p2");
            }

            if (p1.Equals(p3))
            {
                Console.WriteLine("p1 is equal to p3");
            }
            else
            {
                Console.WriteLine("p1 isn't equal to p3");
            }

            //Output:
            // Hello World!
            // p1 isn't equal to p2
            // p1 is equal to p3

            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p2.GetHashCode());
            Console.WriteLine(p3.GetHashCode());

            //Output:
            // p1 will have same hash code as p3, but p2 will be different

        }
    }

    /// <summary>
    /// The record type automatically synthesises equals and tohashcode methods for you. Note that immutability is recommended but not mandatory - the record type will still work if setters are included for the properties.
    /// </summary>
    public record Person
    {
        public string LastName { get; }
        public string FirstName { get; }

        public Person(string first, string last) => (FirstName, LastName) = (first, last);
    }
}
