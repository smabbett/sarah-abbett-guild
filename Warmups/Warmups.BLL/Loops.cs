using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string cray = "";
            for (int i = 0; i < n; i++)
            {
                cray = cray + str;

            }
            return cray;
        }

        public string FrontTimes(string str, int n)
        {
            string cray = "";
            if (str.Length < 3)
            {
                for (int i = 0; i < n; i++)
                {
                    cray = cray + str;
                }
                return string.Format("{0}", cray);
            }
            else
            {
                string sub = str.Substring(0, 3);

                for (int i = 0; i < n; i++)
                {
                    cray = cray + sub;
                }
                return string.Format("{0}", cray);
            }


        }

        public int CountXX(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                char current = str[i];
                char next = str[i + 1];


                if ((current == 'x') && (next == 'x'))
                {
                    count++;
                }
            }
            return count;
        }

        public bool DoubleX(string str)
        {

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x')
                {
                    if (str[i + 1] == 'x')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;

        }

        public string EveryOther(string str)
        {

            string cray = "";

            if (str.Length < 3)
            {
                cray = str.Substring(0, 1);
            }
            else

            {
                for (int i = 0; i < str.Length; i += 2)
                {
                    cray = cray + str.Substring(i, 1);
                }

            }
            return cray;

        }

        public string StringSplosion(string str)
        {
            string sub2 = "";
            for (int i = 1; i < str.Length; i++)
            {
                string sub = str.Substring(0, i);
                sub2 = sub2 + sub;
            }
            return sub2 + str;
        }

        public int CountLast2(string str)
        {
            int count = 0;
            string sub = str.Substring(str.Length - 2, 2);
            for (int i = 0; i < str.Length - 2; i++)
            {

                string sub2 = str.Substring(i, 2);
                if (sub2 == sub)
                {
                    count += 1;
                }

            }
            return count;
        }

        public int Count9(int[] numbers)
        {
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    count += 1;
                }
            }
            return count;
        }

        public bool ArrayFront9(int[] numbers)
        {
            if (numbers.Length < 4)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;

                    }
                    else
                    {
                        continue;
                    }


                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (numbers[i] == 9)
                    {
                        return true;

                    }
                    else
                    {
                        continue;
                    }

                }
            }
            return false;


        }

        public bool Array123(int[] numbers)
        {
            if (numbers.Length < 3)
            {
                return false;
            }

            else
            {
                int x;
                int y;
                int z;
                for (int i = 0; i < numbers.Length - 2; i++)
                {
                    x = numbers[i];
                    y = numbers[i + 1];
                    z = numbers[i + 2];
                    if (x==1 && y ==2 && z==3)
                    {
                        return true;
                    }
                  
                }
                return false;
            }

           
        }

        public int SubStringMatch(string a, string b)
        {
            int count = 0;
            if (a.Length < b.Length)
            {

                for (int i = 0; i < a.Length - 1; i++)
                {
                    string sub = a.Substring(i, 2);
                    string sub2 = b.Substring(i, 2);
                    if (sub == sub2)
                    {
                        count += 1;
                    }
                }
                return count;
            }
            else
            {

                for (int i = 0; i < b.Length - 1; i++)
                {
                    string sub = a.Substring(i, 2);
                    string sub2 = b.Substring(i, 2);
                    if (sub == sub2)
                    {
                        count += 1;
                    }
                }
                return count;
            }
        }

        public string StringX(string str)
        {
            if ((str[0] == 'x') && (str[str.Length - 1] == 'x'))
            {
                str = str.Replace("x","");
                return string.Format("x{0}x", str);
            }
            else if (str[0] == 'x')
            {
                str = str.Replace("x", "");
                return string.Format("x{0}", str);
            }
            else if (str[str.Length - 1] == 'x')
            {
                str = str.Replace("x", "");
                return string.Format("{0}x", str);
            }
            else
            {
                str = str.Replace("x", "");
                return str;
            }
        }

        public string AltPairs(string str)
        {
            for (int i = 2; i < str.Length; i += 2)
            {
                str = str.Remove(i, 2);
            }
            return str;
        }
            



        public string DoNotYak(string str)
        {
            int x = str.IndexOf("yak");
            str = str.Remove(x, 3);
            return str;
        }

        public int Array667(int[] numbers)
        {
            int count=0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == 6 && numbers[i + 1] == 6)
                {
                    count += 1;
                }
                else if (numbers[i] == 6 && numbers[i + 1] == 7)
                {
                    count += 1;
                }
            }
            return count;
            
        }

        public bool NoTriples(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 3; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    if (numbers[i + 1] == numbers[i + 2])
                    {
                        return false;

                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
            return true;
        }

        public bool Pattern51(int[] numbers)
        {

            for (int i = 0; i <= numbers.Length - 3; i++)
            {
                if ((numbers[i] + 5) == numbers[i + 1])
                {
                    if ((numbers[i] - 1) == numbers[i + 2])
                    {
                        return true;

                    }
                }
                
            }
            return false;
        }

    
    }
}
