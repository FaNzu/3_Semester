using System;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i<100; i++)
            {
                bool Fizz = i % 2 == 1;
                bool Buzz = i % 2 == 0;

                if (Fizz)
                {
                    Console.WriteLine("odd");
                }
                else if (Buzz)
                {
                    Console.WriteLine("even");
                }
                else if (Fizz && Buzz)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }



            Console.ReadKey();
        }
    }
}