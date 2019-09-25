using System;

namespace Demo.Patterns
{
    public class Systembolaget_Sergel
    {
        public static bool IsOpen(DayOfWeek weekday)
        {
            return weekday switch
            {
                DayOfWeek.Monday => true,
                DayOfWeek.Tuesday => true,
                DayOfWeek.Wednesday => true,
                DayOfWeek.Thursday => true,
                DayOfWeek.Friday => true,
                DayOfWeek.Saturday => true,
                DayOfWeek.Sunday => false
            };
        }

        public static bool IsOpen(DateTime day)
        {
            return day switch
            {
                _ when Before10(day) => false,
                _ when After20(day) => false,
                _ when After15Saturday(day) => false,
                _ when IsSunday(day) => false,
                _ => true
            };

            static bool Before10(DateTime day) => day.TimeOfDay.Hours < 10;
            static bool After20(DateTime day) => day.TimeOfDay.Hours > 20;
            static bool After15Saturday(DateTime day) => day.DayOfWeek == DayOfWeek.Saturday && day.TimeOfDay.Hours > 15;
            static bool IsSunday(DateTime day) => day.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
