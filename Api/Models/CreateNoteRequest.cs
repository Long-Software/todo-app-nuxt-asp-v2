using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class CreateNoteRequest
{
  [Required]
  [MinLength(1)]
  public string Title { get; set; } = string.Empty;
}