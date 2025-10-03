
using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Note
{
  public int Id { get; set; }
  public string Title { get; set; } = string.Empty;
  public string Content { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}