using System;

namespace TddBuddy.EntityFramework.Utils.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow
        {
            get
            {
                var dateTime = DateTime.Now;
                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            }
        }
    }
}
