using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            if ((isWeekend) && (cigars >= 40))
            {
                return true;
            }

            if ((isWeekend == false) && (cigars >=40) && (cigars <= 60))
            {
                return true;
            }
            else 
            {
                return false;
            }
        
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            int table;
            if (((yourStyle >= 8) && (dateStyle > 2)) || ((yourStyle > 2) && (dateStyle >= 8)))
                {
                table = 2;
                return table;
            }
            if ((yourStyle > 2) && (dateStyle > 2))
            {
                table = 1;
                return table;
            }
            else
            {
                table = 0;
                return table;
            }
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            if ((temp >=60 && temp<= 90) || ((temp >= 60 && temp <= 100) && (isSummer)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int x;
            if (isBirthday == true)
            {
                
                if (speed <= 65)
                {
                    x = 0;
                    return x;
                }
                else if ((speed > 65) && (speed <= 85))
                {
                    x = 1;
                    return x;
                }
                else
                {
                    x = 2;
                    return x;
                }
            }
            else
            {
                if (speed <= 60)
                {
                    x = 0;
                    return x;
                }
                else if ((speed > 60) && (speed <= 80))
                {
                    x = 1;
                    return x;
                }
                else
                {
                    x = 2;
                    return x;
                }
            }
                      
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if ((sum > 9) && (sum < 20))
            {
                sum = 20;
                return sum;
            }
            else
            {
                return sum;
            }
            

            
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            if (vacation == true)
            {
                if ((day == 0) || (day == 6))
                {
                    return "off";
                }
                else
                {
                    return "10:00";
                }
            }
            else
            {
                if ((day == 0) || (day == 6))
                {
                    return "10:00";
                }
                else
                {
                    return "7:00";
                }
            }
           

        }
        
        public bool LoveSix(int a, int b)
        {
            if ((a==6) || (b == 6))
            {
                return true;
            }
            else if (a + b == 6)
            {
                return true;
            }
            else if (a - b == 6)
            {
                return true;
            }
            else
            {
                return false;
            }

              
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            if (outsideMode == true)
            {
                if ((n <= 1) || (n >= 10))
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
                if ((n >= 1) && (n <= 10))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public bool SpecialEleven(int n)
        {
            if (n % 11 == 0)
            {
                return true;
            }
            else if (n % 11 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod20(int n)
        {
            if (n % 20 == 1)
            {
                return true;
            }
            else if (n % 20 == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool Mod35(int n)
        {
            if (n % 3 == 0)
            {
                if (n % 5 == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (n % 5 == 0)
            {
                if (n % 3 == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            if (isAsleep)
            {
                return false;
            }
            else
            {
                if (isMorning == true)
                {
                    if (isMom)
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
                    return true;
                }
            }
            
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            if (a + b == c)
            {
                return true;
            }
            else if (b + c == a)
            {
                return true;
            }
            else if (a + c == b)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if (bOk == true)
            {
                if (c > b)
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
                if ((c > b) && (b > a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (equalOk == true)
            {
                if ((c >= b) && (b >= a))
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
                if ((c>b)&& (b > a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            if ((a - b) % 10 == 0)
            {
                return true;
            }
            else if ((b - c) % 10 == 0)
            {
                return true;
            }
            else if ((c - a) % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
           if (noDoubles == true)
            {
                if (die1 == die2)
                {
                    if (die1 == 6)
                    {
                        die1 = 1;
                        return die1 + die2;                    
                    }
                    else
                    {
                        die1 += 1;
                        return die1 + die2;
                    }
                    
                }
                else
                {
                    return die1 + die2;
                }
            }
           else
            {
                return die1 + die2;
            }
            
        }

    }
}
