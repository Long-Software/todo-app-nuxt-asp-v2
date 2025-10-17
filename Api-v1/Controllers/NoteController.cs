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
        return notes;
    }

    [HttpGet]
    [Route("{id:int}")]
    public ApiResult<Note> GetNote(int id)
    {
        return _noteService.GetNote(id);
    }

    [HttpPost]
    public ApiResult CreateNote(CreateNoteRequest req)
    {
        return _noteService.CreateNote(req);
    }

    [Route("{id:int}")]
    [HttpPatch] 
    public ApiResult UpdateNote(int id, UpdateNoteRequest req)
    {
        req.Id = id;
        return _noteService.UpdateNote(req);
    }

    [Route("{id:int}")]
    [HttpDelete]
    public ApiResult DeleteNote(int id)
    {
        return _noteService.DeleteNote(id);
    }
}