using System;
using System.Runtime.Remoting;
using Dynamitey;
using Dynamitey.DynamicObjects;

namespace ReallyLateBindingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic d1, d2, d3, d4, d5;
            SetupData(out d1, out d2, out d3, out d4, out d5);

            Console.WriteLine($"Dynamic {nameof(d1)} and {nameof(d2)} equal? {CompareDynamics(d1, d2)}");
            Console.WriteLine($"Dynamic {nameof(d1)} and {nameof(d3)} equal? {CompareDynamics(d1, d3)}");
            Console.WriteLine($"Dynamic {nameof(d2)} and {nameof(d4)} equal? {CompareDynamics(d2, d4)}");
            Console.WriteLine($"Dynamic {nameof(d3)} and {nameof(d5)} equal? {CompareDynamics(d3, d5)}");
        }

        private static void SetupData(out dynamic d1, out dynamic d2, out dynamic d3, out dynamic d4, out dynamic d5)
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();

            Address a1 = new Address() { Address1 = "1 Main Street", Telephone = 1234 };
            Address a2 = new Address() { Address1 = "1 Main Street", Telephone = 1234 };
            Address a3 = new Address() { Address1 = "2 Main Street", Telephone = 1234 };
            Address a3a = new Address() { Address1 = "2 Main Street", Telephone = 1234 };
            Address a4 = new Address() { Address1 = "1 Main Street", Telephone = 12345 };

            var now = DateTime.Now;
            Person p1 = new Person() { Name = "Ms A", Id = 1, Guid = g1, Address = a1, Birthday = now, Savings = 1.99f, FavouriteFoods = new string[] { "Burgers", "Chips" } };
            Person p2 = new Person() { Name = "Ms B", Id = 2, Guid = g2, Address = a2, Birthday = now, Savings = 1.99f, FavouriteFoods = new string[] { "Burgers", "Chips" } };
            Person p3 = new Person() { Name = "Ms A", Id = 1, Guid = g1, Address = a3, Birthday = now, Savings = 1.99f, FavouriteFoods = new string[] { "Burgers", "Chips" } };
            Person p4 = new Person() { Name = "Ms B", Id = 2, Guid = g2, Address = a4, Birthday = now, Savings = 1.99f, FavouriteFoods = new string[] { "Burgers", "Chips" } };
            Person p5 = new Person() { Name = "Ms A", Id = 1, Guid = g1, Address = a3a, Birthday = now, Savings = 1.99f, FavouriteFoods = new string[] { "Burgers", "Chips" } };

            d1 = p1;
            d2 = p2;
            d3 = p3;
            d4 = p4;
            d5 = p5;
        }

        private static bool CompareDynamics(dynamic d1, dynamic d2)
        {
            var props = Dynamic.GetMemberNames(d1);
            bool identical = true;           

            foreach (var prop in props)
            {
                var value1 = Dynamic.InvokeGet(d1, prop);
                var value2 = Dynamic.InvokeGet(d2, prop);
                var propsInner = Dynamic.GetMemberNames(value1);

                //All primitives except String will have zero props
                if (propsInner.Count > 0)
                {

                    //Are we looking at strings?
                    Type type = value1.GetType();

                    if (type == typeof(String) || type.IsValueType)
                    {
                        if (value1 != value2)
                        {
                            identical = false;
                            break;
                        }
                    }
                    else if (type.IsArray)
                    {
                        bool arraysIdentical = CompareArrays(value1, value2);

                        if (!arraysIdentical)
                        {
                            identical = false;
                            break;
                        }
                    }
                    else if (!CompareDynamics(value1, value2)) //If the property is a nested object recurse
                    {
                        identical = false;
                        break;
                    }
                    else //reference types that are the same
                    {
                        identical = true;
                        break;
                    }

                }
                else if (value1 != value2)
                {
                    identical = false;
                    break;
                }
                else
                {
                    identical = true;
                }
            }

            return identical;
        }

        private static bool CompareArrays(dynamic value1, dynamic value2)
        {
            bool identical = true;            

            for (int i = 0; i < value1.Length; i++)
            {
                var innerValue1 = value1[i];
                var innerValue2 = value2[i];

                var propsInner = Dynamic.GetMemberNames(value1);

                //All primitives except String will have zero props
                if (propsInner.Count > 0)
                {

                    //Are we looking at strings?
                    Type type = innerValue1.GetType();

                    if (type == typeof(String) || type.IsValueType)
                    {
                        if (innerValue1 != innerValue2)
                        {
                            identical = false;
                            break;
                        }
                    }
                    else if (type.IsArray) //are we looking at an array?
                    {
                        bool arraysIdentical = CompareArrays(innerValue1, innerValue2);

                        if (!arraysIdentical)
                        {
                            identical = false;
                            break;
                        }
                    }
                    else if (CompareDynamics(innerValue1, innerValue2)) //are we looking at a class?
                    {
                        identical = true;
                    }
                    else //reference types that are the same
                    {
                        identical = false;
                        break;
                    }

                }
                else if (innerValue1 != innerValue2)
                {
                    identical = false;
                    break;
                }
                else
                {
                    identical = true;
                }
            }

            return identical;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public float Savings { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public Address Address { get; set; }
        public string[] FavouriteFoods { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public int Telephone { get; set; }
    }
}
