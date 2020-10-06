using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime today = DateTime.Today;
            return today;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            string date = new DateTime(year, month, day).ToString("M/d/yy");
            return date;


        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            DateTime d1 = DateTime.Parse(date);
            return d1;
        }
      


        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            DateTime d2 = DateTime.Parse(date);
            string d3 = d2.ToString("MM.dd.yyyy hh:mm tt");
            return d3;

        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime d2 = DateTime.Parse(date);
            d2 = d2.AddMonths(6);
            string d3 = d2.ToString("MMMM d, yyyy");
            return d3;
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime d4 = DateTime.Parse(date);
            d4 = d4.AddDays(-30);
            string d5 = d4.ToString("MMMM d, yyyy");
            return d5;
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {        
            DateTime d1 = DateTime.Parse(startDate);
            DayOfWeek day = d1.DayOfWeek;

            switch (day)
            {
                case DayOfWeek.Sunday:
                    d1 = d1.AddDays(3);
                    break;
                case DayOfWeek.Monday:
                    d1 = d1.AddDays(2);
                    break;
                case DayOfWeek.Tuesday:
                    d1 = d1.AddDays(1);
                    break;
                case DayOfWeek.Wednesday:
                    break;
                case DayOfWeek.Thursday:
                    d1 = d1.AddDays(6);
                    break;
                case DayOfWeek.Friday:
                    d1 = d1.AddDays(5);
                    break;
                case DayOfWeek.Saturday:
                    d1 = d1.AddDays(4);
                    break;
                default:
                    break;
            }
            DateTime[] wednesdays = new DateTime[count];
            for (int i = 0; i < wednesdays.Length; i++)
            {
                wednesdays[i] = d1.AddDays(7*i);
            }
            return wednesdays;
        }
    }
}
