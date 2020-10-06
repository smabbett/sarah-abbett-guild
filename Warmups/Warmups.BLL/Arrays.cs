using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            if (numbers[0] == 6)
            {
                return true;
            }
            
            if (numbers[numbers.Length - 1] == 6)
            {
                return true;
            }
            
            else
            return false;
        }

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers[0] == numbers[numbers.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int[] MakePi(int n)
        {
            int[] pi = { 3,1,4,1,5,9,2,6,5,3,5,8,9,7,9,3,2,3,8,4,6 };
            int[] c = new int[n];
            for (int i = 0; i < n; i++)
            {
                c[i] = pi[i];
            }
            return c;
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            if ((a[0] == b[0])&&(a[a.Length - 1] == b[b.Length - 1]))
            {
                return true;
            }
            else if (a[0] == b[0])
            {
                return true;
            }
            else if (a[a.Length - 1] == b[b.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int Sum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    

    public int[] RotateLeft(int[] numbers)
        {
            int temp;
            temp = numbers[0];

            for (int i = 0; i < numbers.Length - 1; i++)
            {   
                numbers[i] = numbers[i + 1];
            }
            numbers[numbers.Length - 1] = temp;
            return numbers;
        }


        public int[] Reverse(int[] numbers)
        {
            int temp;
            for (int i = 0; i < numbers.Length/2; i++) {
                temp = numbers[i];
                numbers[i] = numbers[numbers.Length-1-i];
                numbers[numbers.Length - 1-i] = temp;
            }
            
            return numbers;
        }
        
        public int[] HigherWins(int[] numbers)
        {
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                for (int i = numbers.Length-1; i > 0; i--)
                {
                    numbers[i] = numbers[0];
                }
                return numbers;
            }
            else if (numbers[numbers.Length - 1] > numbers[0])
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[numbers.Length - 1];
                }
                
            }
            return numbers;
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            int[] c= new int[2];
            c[0] = a[1];
            c[1] = b[1];
            return c;

            
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
                
            }
            return false;
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] c = new int[numbers.Length*2];
            c[c.Length - 1] = numbers[numbers.Length - 1];
            return c;
        }
        
        public bool Double23(int[] numbers)
        {
            int twos = 0;
            int threes = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 2)
                {
                    twos += 1;
                }
            }
             for (int i = 0; i < numbers.Length; i++)
             {
                if (numbers[i] == 3)
                {
                    threes += 1;
                }
            }
            if ((twos == 2)|| (threes == 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if ((numbers[i]==2)&&(numbers[i+1]==3))
                {
                    numbers[i + 1] = 0;
                }
            }
            return numbers;
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (((numbers[i] == 1) && (numbers[i + 1] == 3)) || ((numbers[numbers.Length - 2] == 1) && (numbers[numbers.Length - 1] == 3)))
                {
                    return true;
                }

            }
            return false;
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] c = new int[2];
            {
                if (a.Length > 1)
                {
                    c[0] = a[0];
                    c[1] = a[1];
                }
                else if (a.Length == 1)
                {
                    c[0] = a[0];
                    c[1] = b[0];
                }
                else
                {
                    c[0] = b[0];
                    c[1] = b[1];
                }
                
            }
            return c;
        }

    }
}
