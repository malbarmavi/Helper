using System;

namespace Helper
{
    public static class Dates
    {
        public static TimeSpan DatesDifference(DateTime presenttDate, DateTime pastDate)
        {
            if (presenttDate > pastDate)
            {
                return (presenttDate - pastDate);
            }
            else
                return new TimeSpan();
        }
    }
}