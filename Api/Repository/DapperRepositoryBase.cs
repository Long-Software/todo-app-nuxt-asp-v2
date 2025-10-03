using System.Data;
using System.Data.Common;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Api.Repository;

public class DapperRepositoryBase(string connectionString)
{
  private readonly string _connectionString = connectionString;

  private DbConnection CreateConnection()
  {
    return new SqlConnection(_connectionString);
  }

  public IEnumerable<T> Query<T>(string storedProcedure, object param = null)
  {
    using DbConnection conn = CreateConnection();
    try
    {
      return conn.Query<T>(storedProcedure, param);
    }
    catch (Exception e)
    {
      throw new Exception($"Failed to run query: {storedProcedure}: Exception {e.Message}");
    }
    finally
    {
      conn.Close();
    }
  }

  public int ExecuteScalar(string storedProcedure, object param = null)
  {
    using var conn = CreateConnection();
    try
    {
      return conn.ExecuteScalar<int>(storedProcedure, param, null, null, CommandType.StoredProcedure);
    }
    catch (Exception e)
    {
      throw new Exception($"Failed to run query: {storedProcedure}: Exception {e.Message}");
    }
    finally
    {
      conn.Close();
    }
  }
}