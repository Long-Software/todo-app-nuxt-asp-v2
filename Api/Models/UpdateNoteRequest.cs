using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Primitives;

namespace Api.Models;

public class UpdateNoteRequest
{
  public int Id { get; set; }
  [Required]
  [MinLength(1)]
  public string Title { get; set; } = string.Empty;
  [Required]
  [MinLength(1)]
  public string Content { get; set; } = string.Empty;

}