using System;

namespace TddBuddy.EntityFramework.Utils.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime DateTimeNow { get; }
    }
}
