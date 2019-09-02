using System;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();
            var result = mc.DoSomething("world", "hello");
            Console.WriteLine(result);

            MyClass2<MyClass> myClass2 = new MyClass2<MyClass>();
            myClass2.Process(mc);

            //MyClass2<MyClass3> myClass2 = new MyClass2<MyClass3>(); //results in compilation error because the generic expected type list does not include int

            Console.ReadLine();
        }
    }

    class MyClass3
    {

    }

    class MyClass
    {
        public string Message { get; set; } = "Hello World!";

        internal (T, T) DoSomething<T>(T valueOne, T valueTwo)
        {
            T temp = valueOne;
            valueOne = valueTwo;
            valueTwo = temp;

            return (valueOne, valueTwo);
        }
    }

    class MyClass2<T> where T: MyClass
    {
        internal void Process(T myClass)
        {
            Console.WriteLine("The message is: " + myClass.Message);
        }
    }
}
