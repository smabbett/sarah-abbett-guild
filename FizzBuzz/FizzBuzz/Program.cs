using System;

namespace FizzBuzz
{
    /*
    In the PrintNumbers() Method below:
    Write a loop that outputs the numbers from 1 to 100 to the console
    If the number is a multiple of 3, print the word “Fizz” next to the number
    If the number is a multiple of 5, print the word “Buzz” next to the number
    If it is both, print “FizzBuzz” next to the number
    */

    class Program
    {
        static void Main(string[] args)
        {
            PrintNumbers();
            Console.ReadLine();
        }

        static void PrintNumbers()
        {
            for (int i = 1; i <=100; i++)
            {
                if ((i % 3 == 0) && (i % 5 == 0))
                {
                    Console.WriteLine("{0} FizzBuzz", i);
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("{0} Fizz", i);
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("{0} Buzz", i);
                }
                else
                {
                    Console.WriteLine("{0}", i);
                }
            }
        }
    }
}
