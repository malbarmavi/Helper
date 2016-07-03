using Helper.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Helper
{
  public static class DataBase
  {
    public static bool TestConnectionString(string connectionString)
    {
      try
      {
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
          cnn.Open();
          return true;
        }
      }
      catch (Exception)
      {
        return false;
      }
    }

    public static Result<DataTable> GetData(string sqlStatement, string connectionString)
    {
      var result = new Result<DataTable>();
      try
      {
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
          using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, cnn))
          {
            da.Fill(result.Data);
          }
        }
        result.State = true;
        return result;
      }
      catch (Exception ex)
      {
        result.ExceptionData = ex;
        return result;
      }
    }

    public static Result<object> ExecuteNonQuery(string sqlStatement, string connectionString)
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
        return new Result<object>()
        {
          State = true
        };
      }
      catch (Exception ex)
      {
        return new Result<object>
        {
          State = false,
          ExceptionData = ex
        };
      }
    }

    public static Result<object> ExecuteScalar(string sqlStatement, string connectionString)
    {
      var result = new Result<object>();
      try
      {
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
          cnn.Open();
          using (SqlCommand cmd = new SqlCommand(sqlStatement, cnn))
          {
            result.Data = cmd.ExecuteScalar();
            result.State = true;
          }
        }
        return result;
      }
      catch (Exception ex)
      {
        result.ExceptionData = ex;
        return result;
      }
    }
  }
}