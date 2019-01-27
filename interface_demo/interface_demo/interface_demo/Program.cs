using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interface_demo
{
    class Program
    {
        interface IShape
        {
            double X { get; set; }
            double Y { get; set; }
            void Draw();
            //void Render(); //if we uncomment this line the Square class will not compile because it must implement the method Render()
        }

        class Square : IShape
        {
            private double _mX, _mY;

            public void Draw()
            {
                Console.WriteLine("I'm a square!");
            }

            public double X
            {
                set { _mX = value; }
                get { return _mX; }
            }

            public double Y
            {
                set { _mY = value; }
                get { return _mY; }
            }
        }

        static void Main(string[] args)
        {
            Square sq = new Square();
            sq.Draw();
        }
    }
}
