using System;

namespace Delegates
{
    internal class Program
    {
        public delegate int Transformer(int x);
        public delegate void Void(int x);

        private static void Main(string[] args)
        {
            Transformer t1 = Square;
            Transformer t2 = delegate(int x) { return x * x; };
            Transformer t3 = x => { return x * x; };
            Transformer t4 = x => x * x;

            int LocalSquare(int x)
            {
                return x * x;
            }

            Transformer t5 = LocalSquare;

            Console.WriteLine(t1(3));
            Console.WriteLine(t2(3));
            Console.WriteLine(t3(3));
            Console.WriteLine(t4(3));
            Console.WriteLine(t5(3));


            Func<int, int> func = i => i + 1;
            Console.WriteLine(func(100));

            Void voids = Console.WriteLine;
            voids += Console.WriteLine;
            voids += Console.WriteLine;

            voids(2);
        }

        public static int Square(int x)
        {
            return x * x;
        }

        public static int Add(int x)
        {
            return x + x;
        }
    }
}