using AutoFixture;
using Dynamitey;
using System;

namespace ReallyLateBindingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange test data
            Fixture fixture = new Fixture();
            Person p1 = fixture.Create<Person>();
            Person p2 = fixture.Create<Person>();
            Person p3 = fixture.Create<Person>();
            Person p4 = fixture.Create<Person>();
            Person p5 = fixture.Create<Person>();

            dynamic d0 = p1;
            dynamic d1 = p2;
            dynamic d2 = p3;
            dynamic d3 = p4;
            dynamic d4 = p5;
            dynamic d5 = p1.ShallowCopy(); //uses the same base data as d1 to confirm we get a positive match
           
            dynamic[] data = new dynamic[] { d0, d1, d2, d3, d4, d5 };

            //Perform our comparisons
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (i == j)
                        continue;

                    Console.WriteLine($"Dynamics d{i} and d{j} equal? {CompareDynamics(data[i], data[j])}");
                }
            }
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
        //Value types
        public int Id { get; set; }
        public float Age { get; set; }
        public char FavouriteLetter { get; set; }
        public DateTime Birthday { get; set; }
        public Guid Guid { get; set; }
        public decimal Savings { get; set; }
        public long FavouriteNumber { get; set; }
        public bool AfraidOfGhosts { get; set; }
        public TimeSpan ActiveTime { get; set; }
        public FavouriteSharkMovie FavouriteSharkMovie { get; set; }

        //Reference types
        public string Name { get; set; }
        public Address Address { get; set; }
        public string[] FavouriteFoods { get; set; }

        //although delegate has been included as a reference type it doesn't get compared because you never assign a value to it
        public delegate string PersonDelegate(string message1, string message2);

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

    }

    public enum FavouriteSharkMovie
    {
        Jaws,Sharknado,Jaws2
    }

    public class Address
    {
        public string Address1 { get; set; }
        public int Telephone { get; set; }
    }
}
