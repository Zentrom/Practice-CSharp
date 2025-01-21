using System;

namespace Practice_CSharp.OfflineBook
{
    public class BReference71
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        public void Run()
        {
            //Assign by Value
            int x = 10;
            int y = x;
            int z = 12;
            bool first = x == y; //true
            bool second = y == z; //false
            Console.WriteLine(String.Format("{0}, {1}", first, second));
            //Assign by Reference
            Point A = new Point { X = 1, Y = 2, Z = 3 };
            Point B = A;
            Point C = new Point { X = 1, Y = 2, Z = 3 };
            Console.WriteLine(A == C); //False, NOT same address
            Console.WriteLine(A == B); //True, same address
        }
    }
}
