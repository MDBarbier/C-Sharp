using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var test = new Stack<int>();
            //test.Push(5);
            //test.Push(10);
            //int x = test.Pop();
            //Console.WriteLine(x);
            //int y = test.Pop();
            //Console.WriteLine(y);
            //Console.ReadLine();

            string a = "a";
            string b = "b";
            int c = 3;
            int d = 4;

            TestGeneric<string>(ref a, ref b);
            TestGeneric<int>(ref c, ref d);

            Console.WriteLine($"a = {a}, b = {b}, c = {c}, d = {d}");
            Console.ReadLine();
        }

        private static void TestGeneric<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    public class Stack<T>
    {
        int position;
        T[] data = new T[100];
        public void Push (T obj) => data[position++] = obj;
        public T Pop() => data[position--];
    }
}
