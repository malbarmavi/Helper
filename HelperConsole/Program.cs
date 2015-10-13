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

            for(int i=0;i<50;i++)
            {
                Console.WriteLine(Helper.Strings.GetRandomString());
            }

            Console.WriteLine(Helper.Cryptography.generateMD5("123456"));
            Console.ReadKey();
        }
    }
}
