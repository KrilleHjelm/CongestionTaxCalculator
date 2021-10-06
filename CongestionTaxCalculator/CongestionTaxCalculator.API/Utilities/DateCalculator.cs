using System;

namespace CongestionTaxCalculator.API.Utilities
{
    public static class DateCalculator
    {
        /// <summary>
        /// Calculates the first sunday of the next month.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime GetFirstSundayOfNextMonth(DateTime date)
        {
            var firstDayOfNextMonth = new DateTime(date.Year, date.Month + 1, 1);
            DateTime firstSundayOfNextMonth;

            while(firstDayOfNextMonth.DayOfWeek != DayOfWeek.Sunday)
            {
                firstDayOfNextMonth = firstDayOfNextMonth.AddDays(1);
            }

            firstSundayOfNextMonth = firstDayOfNextMonth;

            return firstSundayOfNextMonth;
        }

        public static DateTime GetAscensionDayDate(DateTime easterDate)
        {
            //Easter is always a sunday
            var firstThursdayAfterEasterDate = easterDate.AddDays(4);
            //Five weeks after that is Ascension day (35 days)
            return firstThursdayAfterEasterDate.AddDays(35);
        }

        public static DateTime GetPentecostDayDate(DateTime easterDate)
        {
            //7th sunday after easter
            //7 weeks = 49 days
            var pentecostDay = easterDate.AddDays(49);
            return pentecostDay;
        }
        
        public static DateTime GetMidsummerDate(DateTime date)
        {
            var startPeriodOfMidSummerEve = new DateTime(date.Year, 6, 20);
            DateTime firstSaturday;

            while (startPeriodOfMidSummerEve.DayOfWeek != DayOfWeek.Saturday)
            {
                startPeriodOfMidSummerEve = startPeriodOfMidSummerEve.AddDays(1);
            }

            firstSaturday = startPeriodOfMidSummerEve;

            return firstSaturday;
        }
        public static DateTime GetAllSaintsDayDate(DateTime date)
        {
            var startPeriodOfAllSaintsDay = new DateTime(date.Year, 10, 31);
            DateTime firstSaturday;

            while (startPeriodOfAllSaintsDay.DayOfWeek != DayOfWeek.Saturday)
            {
                startPeriodOfAllSaintsDay = startPeriodOfAllSaintsDay.AddDays(1);
            }

            firstSaturday = startPeriodOfAllSaintsDay;

            return firstSaturday;
        }
    }
}
