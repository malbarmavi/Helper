using Helper.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Helper
{
  public static class DataBase
  {
    /// <summary>
    /// Test is the connection string valid by establish the connection
    /// </summary>
    /// <param name="connectionString"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Get data stored in DataTable objet 
    /// </summary>
    /// <param name="sqlStatement">sql query</param>
    /// <param name="connectionString">sqlserer connection string</param>
    /// <returns></returns>
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
    /// <summary>
    /// Execute ommand like insert,delete...
    /// </summary>
    /// <param name="sqlStatement">sql query</param>
    /// <param name="connectionString">sqlserer connection string</param>
    /// <returns></returns>
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
    /// <summary>
    /// Execute sql statement return single value like count,sum...
    /// </summary>
    /// <param name="sqlStatement">sql query</param>
    /// <param name="connectionString">sqlserer connection string</param>
    /// <returns></returns>
    public static Result<T> ExecuteScalar<T>(string sqlStatement, string connectionString)
    {
      var result = new Result<T>();
      try
      {
        using (SqlConnection cnn = new SqlConnection(connectionString))
        {
          cnn.Open();
          using (SqlCommand cmd = new SqlCommand(sqlStatement, cnn))
          {
            result.Data = Utility.Map<T>(cmd.ExecuteScalar());
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