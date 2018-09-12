using System;

namespace Delegates
{
    internal class Program
    {
        public delegate int Transformer(int x);
        public delegate void Voider(int x);

        private static void Main(string[] args)
        {
            Transformer t1 = Square;
            Console.WriteLine(t1(10));

            Transformer t2 = delegate(int x) { return x * x; };
            Transformer t3 = x => { return x * x; };
            Transformer t4 = x => x * x;

            Console.WriteLine(t2(3));
            Console.WriteLine(t3(3));
            Console.WriteLine(t4(3));

            Func<int, int> func = i => i + 1;
            Console.WriteLine(func(100));

            Voider voiders = Console.WriteLine;
            voiders += Console.WriteLine;
            voiders += Console.WriteLine;

            voiders(2);
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