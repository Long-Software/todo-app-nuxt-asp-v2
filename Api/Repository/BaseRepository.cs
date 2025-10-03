namespace Api.Repository;

public abstract class BaseRepository
{
  protected string connectionString = string.Empty;
  protected readonly ILogger<BaseRepository> _logger;

  public BaseRepository(IConfiguration configuration, ILogger<BaseRepository> logger)
  {
    _logger = logger;
    connectionString = configuration.GetConnectionString("DBConnectionString") ?? "";
  }

  private DapperRepositoryBase _dapperBase
  {
    get
    {
      if (_dapper == null)
      {
        _dapper = new DapperRepositoryBase(connectionString);
      }
      return _dapper;
    }
  }

  private DapperRepositoryBase _dapper { get; set; }

  protected virtual IEnumerable<T> GetData<T>(string storedProcedure, object param = null)
  {
    IEnumerable<T> result = [];
    try
    {
      result = _dapperBase.Query<T>(storedProcedure, param);

    }
    catch (Exception e)
    {
      // TODO: Implement add error logging here
      _logger.LogError("");
    }
    return result;
  }
}