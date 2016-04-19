using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
