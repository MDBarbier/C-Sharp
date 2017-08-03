using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton_test
{
    public sealed class Singleton
    {
        //Prop
        public string Message { get; set; }

        //Constructor
        private Singleton()
        {
            Message = "Hello world!";
        }

        //Field
        public static Singleton Instance { get { return Nested.instance; } }

        //Nested class
        private class Nested
        {
           

            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
                
            }

            internal static readonly Singleton instance = new Singleton();
        }
    }
}
