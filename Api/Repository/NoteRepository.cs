using Api.Models;
using Api.Models.Response;

namespace Api.Repository;


public class NoteRepository : BaseRepository
{
  public NoteRepository(IConfiguration configuration, ILogger<NoteRepository> logger) : base(configuration, logger)
  {
  }

  public List<Note> GetAllNotes()
  {
    return GetData<Note>("GetAllNotes").ToList();
  }

  public Note? GetNote(int id)
  {
    return GetData<Note>("GetNote", new { id }).FirstOrDefault();
  }

  public int CreateNote(CreateNoteRequest req)
  {
    return ExecuteScalar("InsertNote", new { req.Title });
  }

  public int UpdateNote(UpdateNoteRequest req)
  {
    return ExecuteScalar("UpdateNote", new { id = req.Id, title = req.Title, content = req.Content });
  }
  public int DeleteNote(int id)
  {
    return ExecuteScalar("DeleteNote", new { id });
  }
}