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

            var os = Helper.SysyemInfo.GetOperatingSystems();
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
