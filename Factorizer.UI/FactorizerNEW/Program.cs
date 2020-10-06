using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.UI
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

                    //get Calculator for this number
                    Calculator calc = new Calculator(numberToFactor);
              

                    string output = string.Join(",", calc.getFactors());
                    output = output.Replace(",0", "");

                    Console.WriteLine("The factors of {0} are: {1} ", numberToFactor, output);
  
                    if (calc.isPrime())
                    {
                        Console.WriteLine("{0} is a prime number. ", numberToFactor);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a prime number. ", numberToFactor);
                    }
                    
                    if (calc.isPerfect())
                    {
                        Console.WriteLine("{0} is a perfect number. ", numberToFactor);
                    }
                    else
                    {
                        Console.WriteLine("{0} is not a perfect number. ", numberToFactor);
                    }

                }
                else
                {
                    Console.WriteLine("That was not a number!");
                }

                Console.ReadLine();

            }
           
        }
    }


    class Calculator
    {
        public int numberToFactor;
        public int sum;

        public Calculator(int numberToFactor)
        {
            this.numberToFactor = numberToFactor;
        }

        public int [] getFactors()
        {
            int currentIndex=0;
            int[] factors = new int[numberToFactor/2 + 1];
            for (int i = 1; i <= numberToFactor; i++)
            {
                if (numberToFactor % i == 0)
                {
                    
                    factors[currentIndex] = i;
                    sum += factors[currentIndex];
                    currentIndex+=1;
                    
                }                  
        
            }

            return factors;
        }

        public bool isPerfect()
        {
           
            if (sum == numberToFactor * 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isPrime()
        {
            if (sum == numberToFactor + 1)
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
