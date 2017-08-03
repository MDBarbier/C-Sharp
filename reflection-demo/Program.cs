using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace reflection_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare a Object of undefined type
            Object helloobj;

            //Instantiate a new HelloWorld object
            helloobj = new HelloWorld();

            //This will not work, C# does not support automatic late binding
            //helloobj.PrintHello("hiya");

            //Instead we must get the Type and use this to invoke on of it's members using Reflection
            Type t = helloobj.GetType();
            object[] param = new object[1];
            param[0] = "Hello World";
            t.InvokeMember("PrintMessage", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, helloobj, param);
            

            // Using GetType to obtain type information:  
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);

            // Using Reflection to get information from an Assembly:  
            System.Reflection.Assembly info = typeof(System.Int32).Assembly;
            System.Console.WriteLine(info);


            //Example using the dynamic type
            dynamic helloobj2;
            helloobj2 = new HelloWorld();
            helloobj2.PrintMessage("Hello from a dynamic"); //note you don't get intellisense on the dynamic object, you must manually type the method name

            //These will both resolve to Int32 at runtime
            dynamic dyn = 1;
            object obj = 1;

            // Rest the mouse pointer over dyn and obj to see their
            // types at compile time.
            System.Console.WriteLine(dyn.GetType());
            System.Console.WriteLine(obj.GetType());

            Console.ReadLine();   
        }
    }

    class HelloWorld
    {
        public string Message { get; set; }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
