using Api.Models;
using Api.Models.Response;
using Api.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("/api/note")]
[ApiController]
public class NoteController : ControllerBase
{
  private readonly INoteService _noteService;

  public NoteController(INoteService noteService)
  {
    _noteService = noteService;
  }

  [HttpGet]
  public ApiResult<List<Note>> GetAllNotes()
  {
    var notes = _noteService.GetAllNotes();
    return ApiResult<List<Note>>.Success(notes);
  }
  [HttpGet]
  [Route("{id:int}")]
  public ApiResult<Note> GetNote(int id)
  {
    return ApiResult<Note>.Success(new Note());
  }

  [HttpPost]
  public ApiResult CreateNote(CreateNoteRequest req)
  {
    return ApiResult.Success();
  }

  [Route("{id:int}")]
  [HttpPatch]
  public ApiResult UpdateNote(UpdateNoteRequest req)
  {
    return ApiResult.Success();
  }
  [Route("{id:int}")]
  [HttpDelete]
  public ApiResult DeleteNote(int id)
  {
    return ApiResult.Success();
  }
}