using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inheritance_virtual_keyword
{
    public class Resource : IDisposable
    {
        private bool _isClosed = false;    // good programming practice initialise, although default

        protected virtual void Close()
        {
            Console.WriteLine("Base resource closer called!");
        }

        ~Resource()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_isClosed)
            {
                Console.WriteLine("Disposing resource and calling the Close() method...");
                _isClosed = true;
                Close();
            }
        }
    }

    public class AnotherTypeOfResource : Resource
    {
        protected override void Close()
        {
            Console.WriteLine("Another type of resource closer called!");
        }
    }

    public class VirtualMethodDemo
    {
        public static void Main()
        {
            Resource res = new Resource();
            AnotherTypeOfResource res2 = new AnotherTypeOfResource();

            res.Dispose();  // Resource.Close() will be called.
            res2.Dispose(); // Even though Dispose() is part of the Resource class, 
                            // the Resource class will call AnotherTypeOfResource.Close()!
        }
    }


}
