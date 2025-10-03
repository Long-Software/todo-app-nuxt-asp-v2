using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/api/note")]
[ApiController]
public class NoteController : ControllerBase
{
  public async Task<IActionResult> GetAllNotes()
  {
    return Ok();
  }
  public async Task<IActionResult> GetNote()
  {
    return Ok();
  }
}