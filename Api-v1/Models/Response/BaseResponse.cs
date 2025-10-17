namespace Api.Models.Response;

public class BaseResponse
{
  public int? ErrorCode { get; set; }
  public string ErrorMessage { get; set; } = string.Empty;
}