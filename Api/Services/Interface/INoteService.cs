using Api.Models;
using Api.Models.Response;

namespace Api.Services.Interface;

public interface INoteService
{
  ApiResult<List<Note>> GetAllNotes();
  ApiResult<Note> GetNote(int id);
  ApiResult CreateNote(CreateNoteRequest req);
  ApiResult UpdateNote(UpdateNoteRequest req);
  ApiResult DeleteNote(int id);
}