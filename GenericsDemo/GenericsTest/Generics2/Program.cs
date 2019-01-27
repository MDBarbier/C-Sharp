using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics2
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericObjectContainer<int> container = new GenericObjectContainer<int>(25);
            GenericObjectContainer<int> container2 = new GenericObjectContainer<int>(5);
            Console.WriteLine(container.getObject() + container2.getObject());

            Console.ReadKey(); // wait for user to press any key, so we could see results
        }
    }

    public class GenericObjectContainer<T>
    {
        private T _obj;

        public GenericObjectContainer(T obj)
        {
            this._obj = obj;
        }

        public T getObject()
        {
            return this._obj;
        }
    }
}
