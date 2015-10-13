using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class Numbers
    {
        public static int intParse()
        {
            return 0;
        }
        public static double doubleParse()
        {
            return 0;
        }
        private static readonly Random getRandom = new Random();
        private static readonly object syncLock = new object();
        public static int getRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return (getRandom).Next(min, max);
            }
        }
        public static int getRandomNumber()
        {
            return getRandom.Next(int.MinValue, int.MaxValue);
        }

    }
}
