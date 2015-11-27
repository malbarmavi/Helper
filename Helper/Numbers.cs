using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    
    public static class Numbers 
    {
        
        public static T Parse<T>(object number)
        {
            try
            {
                return (T)Convert.ChangeType(number, typeof(T));
            }
            catch (Exception)
            {

                return (T)Convert.ChangeType("0", typeof(T));
            }
        }       
       
        private static readonly Random getRandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return (getRandom).Next(min, max);
            }
        }
        public static int GetRandomNumber()
        {
            return getRandom.Next(int.MinValue, int.MaxValue);
        }
        public static int GetRandomNumber(int max)
        {
            return GetRandomNumber(0, max);
        }
        public static int ToInt(this string value)
        {
            return Parse<int>(value);
        }
        public static Double ToDouble(this string value)
        {
            return Parse<double>(value);
        }
    }
}
