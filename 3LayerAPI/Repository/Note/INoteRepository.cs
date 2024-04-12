namespace _3LayerAPI.Repository.Note
{
    public interface INoteRepository
    {
        Task<bool> NoteExistAsync(string title);
        Task<bool> NoteExistAsync(int id);
        Task<bool> CreateNote(Models.Note note);
        Task<Models.Note> GetNoteByTitleAsync(string title);
        Task<Models.Note> GetNoteByIdAsync(int id);
        Task<ICollection<Models.Note>> GetAllNotesAsync();
        Task<ICollection<Models.Note>> GetNotesAsync();
        Task<ICollection<Models.Note>> GetPrivateNotesAsync();
        Task<ICollection<Models.Note>> GetDeletedNotesAsync();
        Task<bool> UpdateNoteAsync(Models.Note note);
        Task<bool> SoftDeleteNoteAsync(int id);
        Task<bool> HardDeleteNoteAsync(Models.Note note);
    }
}
