using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;


namespace HelperConsole
{
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

            var os = SystemInfo.GetOperatingSystems();
            var user = SystemInfo.GetUserAccounts();
            var sysuser = SystemInfo.GetSystemAccounts();
            var userGroups = SystemInfo.GetUsersGroups();
            var cpu = SystemInfo.GetCPU();
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
    }
}
