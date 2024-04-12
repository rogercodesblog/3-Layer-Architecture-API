
using _3LayerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace _3LayerAPI.Repository.Note
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _db;
        public NoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<bool> CreateNote(Models.Note note)
        { 
            await _db.Notes.AddAsync(note);
            return await SaveChangesAsync();
        }

        public async Task<ICollection<Models.Note>> GetAllNotesAsync()
        {
            return await _db.Notes.ToListAsync();
        }

        public async Task<ICollection<Models.Note>> GetDeletedNotesAsync()
        {
            return await _db.Notes.Where(note=> note.IsDeleted == true).ToListAsync();
        }

        public async Task<Models.Note> GetNoteByIdAsync(int id)
        {
            return await _db.Notes.FirstOrDefaultAsync(note => note.Id == id);
        }

        public async Task<Models.Note> GetNoteByTitleAsync(string title)
        {
            return await _db.Notes.FirstOrDefaultAsync(note => note.Title.ToLower().Contains(title.ToLower()));
        }

        public async Task<ICollection<Models.Note>> GetNotesAsync()
        {
            return await _db.Notes.Where(note => note.IsPrivate == false && note.IsDeleted == false).ToListAsync();
        }

        public async Task<ICollection<Models.Note>> GetPrivateNotesAsync()
        {
            return await _db.Notes.Where(note=>note.IsPrivate == true).ToListAsync();
        }

        public Task<bool> HardDeleteNoteAsync(Models.Note note)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NoteExistAsync(string title)
        {
            return await _db.Notes.AnyAsync(note => note.Title.ToLower().Contains(title.ToLower()));
        }

        public async Task<bool> NoteExistAsync(int id)
        {
            return await _db.Notes.AnyAsync(note => note.Id == id);
        }

        public Task<bool> SoftDeleteNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateNoteAsync(Models.Note note)
        {
            _db.Notes.Update(note);
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
