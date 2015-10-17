using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Helper
{
    public static  class   DataBase
    {
        public static bool TestonnetionString(string connetionStrin)
        {
            var cmd = new SqlCommand();
           
            return true;
        }

        public static DataTable GetData(string sqlStatement,string connetionString)
        {
            return new DataTable();
        }
        public static bool ExecuteNonQuery(string sqlStatement,string connetionString)
        {
            return true;
        }


    }
}
