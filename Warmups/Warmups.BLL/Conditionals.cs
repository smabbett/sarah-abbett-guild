using System;

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile && bSmile)
            {
                return true;
            }
            else if (!aSmile && !bSmile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isVacation)
            {
                return true;
            }
            else if (!isWeekday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b) * 2;
            }
            else
            {
                return a + b;
            }
        }

        public int Diff21(int n)
        {
            if (n > 21)
            {
                return (n - 21) * 2;
            }
            else
            {
                return 21 - n;
            }
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (hour < 7 || hour > 20)
            {
                if (isTalking)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NearHundred(int n)
        {
            if (100 - n <= Math.Abs(10))
            {
                return true;
            }
            else if (200 - n <= Math.Abs(10))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PosNeg(int a, int b, bool negative)
        {
            if (negative)
            {
                if (a < 0 && b < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (a < 0 & b > 0)
                {
                    return true;
                }
                else if (a > 0 & b < 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return String.Format("not {0}", s);
            }
            string sub = s.Substring(0, 3);
            if (sub == "not")
            {
                return String.Format("{0}", s);
            }
            else
            {
                return String.Format("not {0}", s);
            }
        }

        public string MissingChar(string str, int n)
        {
            str = str.Remove(n, 1);
            return str;
        }

        public string FrontBack(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            string sub = str.Substring(1, str.Length - 2);
            string front = str.Substring(0, 1);
            string back = str.Substring(str.Length - 1);
            string frnback = back + sub + front;
            return frnback;

        }

        public string Front3(string str)
        {
            if (str.Length < 3)
            {
                return str + str + str;
            }
            else
            {
                string sub = str.Substring(0, 3);
                return sub + sub + sub;

            }
        }

        public string BackAround(string str)
        {
            string sub = str.Substring(str.Length - 1, 1);
            return sub + str + sub;
        }

        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0)
            {
                return true;
            }
            else if (number % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool StartHi(string str)
        {
            if (str.Length < 3)
            {
                if (str == "hi")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string sub = str.Substring(0, 3);
                if (sub == "hi ")
                {
                    return true;
                }
                else if (sub == "hi,")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
   
        }

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else if (temp2 < 0 && temp1 > 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Between10and20(int a, int b)
        {
            if (a > 9 && a < 21)
            {
                return true;
            }
            else if (b > 9 && b < 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasTeen(int a, int b, int c)
        {
            if (a > 12 && a < 20)
            {
                return true;
            }
            else if (b > 12 && b < 20)
            {
                return true;
            }
            else if (c > 12 && c < 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SoAlone(int a, int b)
        {
            if (a > 12 && a < 20)
            {
                if (b < 13 || b > 19)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (b > 12 && b < 20)
            {
                if (a < 13 || a > 19)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public string RemoveDel(string str)
        {
            string sub = str.Substring(1, 3);
            if (sub == "del")
            {
                str = str.Remove(1, 3);
                return str;
            }
            else
            {
                return str;
            }
        }

        public bool IxStart(string str)
        {
            string sub = str.Substring(1, 2);
            if (sub == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string StartOz(string str)
        {
            string oo = str.Substring(0, 1);
            if (str.Length < 2)
            {
                if (oo == "o")
                {
                    return oo;
                }
                else
                {
                    return "";
                }
            }

            string zz = str.Substring(1, 1);

            if ((oo == "o") && (zz == "z"))
            {
                return oo + zz;
            }
            else if (oo == "o")
            {
                return oo;
            }
            else if (zz == "z")
            {
                return zz;
            }
            else
            {
                return "";
            }
        }

        public int Max(int a, int b, int c)
        {
            if ((a > b) && (a > c))
            {
                return a;
            }
            else if ((b > a) && (b > c))
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        public int Closer(int a, int b)
        {
            int anear = Math.Abs(10 - a);
            int bnear = Math.Abs(10 - b);
            if (anear < bnear)
            {
                return a;
            }
            else if (bnear < anear)
            {
                return b;
            }
            else
            {
                return 0;
            }

        }

        public bool GotE(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                {
                    count += 1;
                }

            }
            if (count > 0 && count < 4)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public string EndUp(string str)
        {
            if (str.Length < 3)
            {
                str = str.ToUpper();
                return str;
            }
            else
            {
                string sub = str.Substring(str.Length - 3, 3);
                sub = sub.ToUpper();
                string begin = str.Substring(0, str.Length - 3);
                return begin + sub;

            }
        }

        public string EveryNth(string str, int n)
        {
            string sub = "";
            for (int i = 0; i < str.Length; i += n)
            {
                sub = sub + str.Substring(i, 1);
            }
            return sub;
        }
    }
}
