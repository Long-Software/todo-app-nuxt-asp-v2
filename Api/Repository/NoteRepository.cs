using Api.Models;
using Api.Models.Response;

namespace Api.Repository;

public class NoteRepository : BaseRepository
{
    public NoteRepository(IConfiguration configuration, ILogger<NoteRepository> logger)
        : base(configuration, logger)
    {
        connectionString = configuration.GetConnectionString("DBConnectionString") ?? "";
    }

    public List<Note> GetAllNotes()
    {
        return GetData<Note>("GetAllNotes_2_0_0").ToList();
    }

    public Note? GetNote(int id)
    {
        return GetData<Note>("GetNote_2_0_0", new { id }).FirstOrDefault();
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