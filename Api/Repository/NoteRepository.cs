using Api.Models;

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

public Note(Get)

}