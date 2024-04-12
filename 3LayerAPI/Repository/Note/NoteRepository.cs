
using _3LayerAPI.Data;

namespace _3LayerAPI.Repository.Note
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _db;
        public NoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Task<bool> CreateNote(Models.Note note)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Models.Note>> GetAllNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Models.Note>> GetDeletedNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Note> GetNoteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Note> GetNoteByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Models.Note>> GetNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Models.Note>> GetPrivateNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> HardDeleteNoteAsync(Models.Note note)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NoteExistAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<bool> NoteExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateNoteAsync(Models.Note note)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
