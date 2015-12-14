using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    namespace Objects
    {
       
       public enum StringCase
        {
            LowerCase = 0,
            UppearCase = 1,
            Both = 2
        }

        public class RandomOptions
        {
            public bool Apphabet { get; set; }
            public bool Symble { get; set; }
            public bool Number { get; set; }
            public StringCase LetterCase { get; set; }

        }

        public class Result
        {
            public bool Success { get; set; }
            public object Data { get; set; }
            public Result()
            {
                Success = false;
                Data = new object();
            }
        }
    }
}
