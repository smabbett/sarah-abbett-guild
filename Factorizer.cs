using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("What number would you like to factor? ");
                string input = Console.ReadLine();

                int numberToFactor;


                if (int.TryParse(input, out numberToFactor))
                {
                    Console.Write("The factors of {0} are: ", numberToFactor);

                    Calculator calc = new Calculator(numberToFactor);

                    calc.getFactors;
                    Console.WriteLine("{0}", i);

                    calc.isPrime;
                    if (isPrime(numberToFactor))
                    {
                        Console.Write("{0} is a prime number.", numberToFactor);
                    }

                    calc.isPerfect;
                    if (isPerfect(numberToFactor))
                    {
                        Console.Write("{0} is a perfect number.", numberToFactor);
                    }

                }
                else
                {
                    Console.WriteLine("That was not a valid number!");
                }
            }

            Console.ReadLine();


        }

        class Calculator
        {
            private int numberToFactor;

            public Calculator(int numberToFactor)
            {
                this.numberToFactor = numberToFactor;
            }

            public int[] getFactors()
            {
                int factorcount = 0;
                for (int i = 0; i <= numberToFactor; i++)
                {
                    if (numberToFactor % i == 0)
                    {
                        getFactors.Add(i);
                        factorcount++;
                        continue;
                    }
                }
            }
            public bool isPrime()

            {
                if (factorcount < 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool isPerfect()
            {
                int sum = 0;
                for (int i = 0; i < getFactors.Length; i++)
                {
                    sum += getFactors[i];
                }
                if (sum == numberToFactor / 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }



    }

}

    

