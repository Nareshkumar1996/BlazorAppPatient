using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Healthware.Assist.Core.Utility
{
    public static class Clock
    {
        static Clock()
        {
            Reset();
        }

        public static DateTime Now()
        {
            return current_time_provider();
        }

        public static Date Today()
        {
            return current_time_provider();
        }

        public static Date FirstDateOfTheCurrentYear()
        {
            return new DateTime(current_time_provider().Year, 1, 1);
        }

        public static void ChangeTimeProviderTo(Func<DateTime> new_time_provider)
        {
            current_time_provider = new_time_provider;
        }
        public static IEnumerable<string> MonthNames()
        {		
            return CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames.Where(x=> !string.IsNullOrEmpty(x));
        }
        
        
        
        public static List<int> ListOfYearsFrom(int minYear)
        {
            var listOfYears = new List<int>();
            var startDate = new DateTime(minYear, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var currentDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day).ToUniversalTime().AddHours(12);

            listOfYears.Add(minYear);
            while (startDate.Year < currentDate.Year)
            {
                startDate = startDate.AddYears(1);
                listOfYears.Add(startDate.Year);
            }
            
            return listOfYears;
        }

        public static void Reset()
        {
            current_time_provider = default_time_provider;
        }

        public static int SecondsSince1970()
        {
            return (int) (Now().ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        public static int AsSecondsSince1970Local()
        {
            return (int)(Now() - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        public static int AsSecondsSince1970()
        {
            return (int)(Now().ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        private static Func<DateTime> current_time_provider;
        private static readonly Func<DateTime> default_time_provider = () => DateTime.UtcNow;
    }
}