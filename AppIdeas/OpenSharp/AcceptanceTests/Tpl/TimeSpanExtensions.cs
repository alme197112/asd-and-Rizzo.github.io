using System;

namespace AcceptanceTests.Helpers
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Times(this TimeSpan current,int multiplicator)
        {
            //TODO: check for big number Contract.Requires();
            return TimeSpan.FromTicks(current.Ticks * multiplicator);
        }
    }
}
