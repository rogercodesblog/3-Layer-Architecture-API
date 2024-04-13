using _3LayerAPI.ServiceResponder;

namespace _3LayerAPI.Services.Note
{
    public interface INoteService
    {
        Task<ServiceResponse<List<DTOs.Note.NoteDTO>>> GetAllNotesAsync();
        Task<ServiceResponse<List<DTOs.Note.NoteDTO>>> GetNotesAsync();
        Task<ServiceResponse<List<DTOs.Note.NoteDTO>>> GetPrivateNotesAsync();
        Task<ServiceResponse<List<DTOs.Note.NoteDTO>>> GetDeletedNotesAsync();
        Task<ServiceResponse<DTOs.Note.NoteDTO>> GetNoteByIdAsync(int id);
        Task<ServiceResponse<DTOs.Note.NoteDTO>> AddNoteAsync(DTOs.Note.CreateNoteDTO createNoteDto);
        Task<ServiceResponse<DTOs.Note.NoteDTO>> UpdateNoteAsync(DTOs.Note.CreateNoteDTO updateNoteDto);
        Task<ServiceResponse<string>> SoftDeleteNoteAsync(int id);
        Task<ServiceResponse<string>> HardDeleteNoteAsync(int id);
    }
}
