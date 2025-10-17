namespace Api.Models.Response;

public class ApiResult
{
  public int ErrorCode { get; set; }

  public string Message { get; set; } = string.Empty;

  private ApiResult() { }

  public static ApiResult Success()
  {
    return new ApiResult()
    {
      ErrorCode = 0,
      Message = "Success"
    };
  }

  public static ApiResult Failure(int errorCode, string message)
  {
    return new ApiResult()
    {
      ErrorCode = errorCode,
      Message = message
    };
  }

}

public class ApiResult<T> where T : class
{
  public T Data { get; set; }

  public int ErrorCode { get; set; }

  public string Message { get; set; }

  private ApiResult() { }

  public static ApiResult<T> Success(T data)
  {
    return new ApiResult<T>()
    {
      Data = data,
      ErrorCode = 0,
      Message = "Success"
    };
  }

  public static ApiResult<T> Failure(int errorCode, string message)
  {
    return new ApiResult<T>()
    {
      Data = null,
      ErrorCode = errorCode,
      Message = message
    };
  }

  public static implicit operator ApiResult<T>(T d) => Success(d);
}