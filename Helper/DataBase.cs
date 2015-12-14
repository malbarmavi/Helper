using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Helper.Objects;

namespace Helper
{
    public static class DataBase
    {
        public static bool TestConnetionString(string connectionString)
        {

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    cnn.Close();
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }


        }

        public static DataTable GetData(string sqlStatement, string connetionString)
        {
            var result = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, cnn))
                    {
                        da.Fill(result);
                    }
                }

                return result;
            }
            catch (Exception)
            {

                return result;
            }

        }

        public static bool ExecuteNonQuery(string sqlStatement, string connectionString)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlStatement, cnn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Result ExecuteScalar(string sqlStatement, string connectionString)
        {
            var result = new Result();
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlStatement, cnn))
                    {
                        result.Data = cmd.ExecuteScalar();
                        result.Success = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }





        }

    }
}
