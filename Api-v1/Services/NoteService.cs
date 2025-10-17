using Api.Models;
using Api.Models.Response;
using Api.Repository;
using Api.Services.Interface;

namespace Api.Services;

public class NoteService : INoteService
{
  private readonly NoteRepository _noteRepository;

  public NoteService(NoteRepository noteRepository)
  {
    _noteRepository = noteRepository;
  }

  public ApiResult<List<Note>> GetAllNotes()
  {
    return ApiResult<List<Note>>.Success(_noteRepository.GetAllNotes());
  }

  public ApiResult<Note> GetNote(int id)
  {
    var note = _noteRepository.GetNote(id);
    if (note == null)
    {
      return ApiResult<Note>.Failure(404, "note not found");
    }
    return ApiResult<Note>.Success(note);
  }

  public ApiResult CreateNote(CreateNoteRequest req)
  {
    var res = _noteRepository.CreateNote(req);
    if (res == 0)
    {
      return ApiResult.Failure(400, "note cannot be created");
    }
    return ApiResult.Success();
  }

  public ApiResult UpdateNote(UpdateNoteRequest req)
  {
    var res = _noteRepository.UpdateNote(req);
    if (res == 0)
    {
      return ApiResult.Failure(400, "note cannot be updated");
    }
    return ApiResult.Success();
  }

  public ApiResult DeleteNote(int id)
  {
    var res = _noteRepository.DeleteNote(id);
    if (res == 0)
    {
      return ApiResult.Failure(400, "note cannot be delete");
    }
    return ApiResult.Success();
  }
}