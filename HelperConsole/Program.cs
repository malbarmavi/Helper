using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
namespace HelperConsole
{
    /*
     Console app to test helper futures and some idea just like a lab .
         */
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 50; i++)
            //{
            //    wl(Helper.Strings.GetRandomString(15, new RandomOptions() { Apphabet = true, LetterCase = StringCase.UppearCase }));
            //}
            //while (Numbers.GetRandomNumber(0,2)!=2)
            //{
            //    wl(Helper.Strings.GetRandomString(15, new RandomOptions() { Apphabet = true,Number=true,Symble=true, AlphabetCase = StringCase.Both }));
            //}
            //wl(Helper.Cryptography.generateMD5("123456"));
            //wl(Helper.Cryptography.GetRandomNumber());
            //wl(Helper.Cryptography.generateMD5("123456"));
            //foreach (var item in new int[] { 1, 2, 3, 4, 5, 6 })
            //{
            //    Console.Write("-");
            //    System.Threading.Thread.Sleep(1000);
            //}
            //var os = SystemInfo.GetOperatingSystems();
            //var user = SystemInfo.GetUserAccounts();
            //var sysuser = SystemInfo.GetSystemAccounts();
            //var userGroups = SystemInfo.GetUsersGroups();
            var cpu = SystemInfo.GetCPU();
            foreach (var i in cpu)
            {

                foreach (var p in i.GetType().GetProperties())
                {
                    Console.WriteLine($" {FormatName(p.Name).PadRight(25)}: {p.GetValue(i).ToString().PadRight(5)}");
                }
            }

            Console.ReadKey();
        }

        static void w(string message)
        {
            Console.WriteLine(message);
        }
        static void wl(string message)
        {
            Console.WriteLine(message);
        }


        public static string FormatName(string value)
        {
            //StringBuilder result = new StringBuilder();

            //foreach (char c in value)
            //{
            //    if (char.IsUpper(c))
            //    {
            //        result.Append($" {c}");
            //    }
            //    else
            //    {
            //        result.Append(c);
            //    }
            //}

            var s = value.Select(c => char.IsUpper(c) ? $" {c}" : c.ToString()).Aggregate((sum, i) => $"{sum}{i}");
            return s;

        }
    }
}
