using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return String.Format("Hello {0}!", name);
        }

        public string Abba(string a, string b)
        {
            return String.Format("{0}{1}{1}{0}", a,b);
        }

        public string MakeTags(string tag, string content)
        {
            return String.Format ("<{0}>{1}</{0}>", tag, content);
        }

        public string InsertWord(string container, string word) { 
            string sub = container.Substring(0, 2);
            string sub2 = container.Substring(2, 2);
            return String.Format ("{0}{1}{2}", sub, word, sub2);
        }

        public string MultipleEndings(string str)
        {
            string end = str.Substring(str.Length - 2, 2);
            return String.Format("{0}{0}{0}", end);
        }

        public string FirstHalf(string str)
        {
            string half = str.Substring(0, str.Length / 2);
            return string.Format("{0}", half);
        }

        public string TrimOne(string str)
        {
            string trim = str.Substring(1, str.Length - 2);
            return string.Format("{0}", trim);
        }

        public string LongInMiddle(string a, string b)
        {
            int x = a.Length;
            int y = b.Length;
            if (x > y)
            {
                return string.Format("{0}{1}{0}", b, a, b);
            }
            else
            {
                return string.Format("{0}{1}{0}", a, b, a);
            }
            
        }

        public string RotateLeft2(string str)
        {
            string left = str.Substring(0, 2);
            string right = str.Substring(2);
            return string.Format("{0}{1}", right, left);
        }

        public string RotateRight2(string str)
        {
            string sub = str.Substring(str.Length - 2, 2);
            string sub2 = str.Substring(0, str.Length - 2);
            return string.Format("{0}{1}", sub, sub2);
        }

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront)
            {
                string sub = str.Substring(0, 1);
                return string.Format("{0}", sub);
            }
            else
            {
                string sub = str.Substring(str.Length - 1, 1);
                return string.Format("{0}", sub);
            }
        }

        public string MiddleTwo(string str)
        {
            string sub = str.Substring(str.Length / 2 - 1, 2);
            return string.Format("{0}", sub);
        }

        public bool EndsWithLy(string str)
        {
            if (str.Length < 2)
                return false;

            string sub = "ly";
            string sub2 = str.Substring((str.Length - 2), 2);

            if (sub == sub2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string FrontAndBack(string str, int n)
        {
            string sub = str.Substring(0,n);
            string sub2 = str.Substring(str.Length - n, n);
            return String.Format("{0}{1}", sub, sub2);
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n == 3)
            {
                string sub = str.Substring(0, 2);
                return String.Format("{0}", sub);
            }
            else
            {
                string sub = str.Substring(n, 2);
                return String.Format("{0}", sub);
            }
            
        }

        public bool HasBad(string str)
        {
            if (str.Length < 3)
            {
                return false;
            }

            string sub = str.Substring(0, 3);
            string sub2 = str.Substring(1, 3);
            if (sub == "bad" || sub2 == "bad" )
            {
                return true;
            }
            else
            { 
                return false;
            }
        }

        public string AtFirst(string str)
        {
            if (str.Length == 0)
                return string.Format("@@");

            else if (str.Length == 1)
            {
                string sub = str.Substring(0, 1);
                return string.Format("{0}@", sub);
            }
            else
            {
                string sub = str.Substring(0, 2);
                return string.Format("{0}", sub);
            }
            

        }

        public string LastChars(string a, string b)
        {
            if (a.Length == 0 && b.Length > 0)
            {
                string last = b.Substring(b.Length - 1, 1);
                return String.Format("@{0}", last);
            }
            else if (b.Length == 0 && a.Length > 0)
            {
                string first = a.Substring(0, 1);
                return String.Format("{0}@", first);
            }

            else if (a.Length == 0 && b.Length == 0)
            {
                return String.Format("@@");
            }

            else
            {
                string sub = a.Substring(0, 1);
                string sub2 = b.Substring(b.Length - 1, 1);
                return string.Format("{0}{1}", sub, sub2);
            }
        }

        public string ConCat(string a, string b)
        {
            if (a == "")
            {
                return String.Format("{0}", b);
            }
            else if (b == "")
            {
                return String.Format("{0}", a);
            }
            else
            { 
                char x = a[a.Length - 1];
                char y = b[0];
                if (x == y)
                {
                    string sub = a.Substring(0, a.Length - 1);
                    return string.Format("{0}{1}", sub, b);


                }
                else
                    return string.Format("{0}{1}", a, b);
            }
        }

        public string SwapLast(string str)
        {
            if (str.Length < 2)
            {
                return string.Format("{0}", str);
            }
            else
            {
                char x = str[str.Length - 2];
                char y = str[str.Length - 1];
                string sub = str.Substring(0, str.Length - 2);
                return string.Format("{0}{1}{2}", sub, y, x);
            }
            

        }

        public bool FrontAgain(string str)
        {
            string sub = str.Substring(0, 2);
            string sub2 = str.Substring(str.Length - 2, 2);
            if (sub == sub2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MinCat(string a, string b)
        {
            int x = a.Length;
            int y = b.Length;
            if (x > y)
            {
                string sub = a.Substring(x - y, y);
                return string.Format("{0}{1}", sub, b);
            }
            else if (y > x)
            {
                string sub = b.Substring(y - x, x);
                return string.Format("{0}{1}", a, sub);
            }
            else
            {
                return string.Format("{0}{1}", a, b);
            }
           
        }

        public string TweakFront(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return String.Format("");
            }
            string sub = str.Substring(2, str.Length - 2);
            if ((str[0] == 'a') && (str[1]=='b'))
            {
                return String.Format("ab{0}", sub);
            } 
            else if (str[0] == 'a')
            {
                return String.Format("a{0}", sub);
            }
            else if (str[1] == 'b')
            {
                return String.Format("b{0}", sub);
            }
            else
            {
                return String.Format("{0}", sub);
            }
        }

        public string StripX(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return String.Format("");
            }
            if ((str.Length == 1)&& (str[0] == 'x'))
            {
                return String.Format("");
            }
           
            else if ((str[0] == 'x') && (str[str.Length - 1] == 'x'))
            {
                string sub = str.Substring(1, str.Length - 2);
                return String.Format("{0}", sub);
            }
            else if (str[0] == 'x')
            {
                string sub = str.Remove(0, 1);
                return String.Format("{0}", sub);
            }
                
            else if (str[str.Length-1] == 'x')
            {
                string sub = str.Remove(str.Length - 1, 1);
                return String.Format("{0}", sub);
            }
            else
            {
                return String.Format("{0}", str);
            }

        }
    }
}
