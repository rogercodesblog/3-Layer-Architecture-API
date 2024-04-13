using _3LayerAPI.DTOs.Note;
using _3LayerAPI.ServiceResponder;

namespace _3LayerAPI.Services.Note
{
    public class NoteService : INoteService
    {
        public Task<ServiceResponse<NoteDTO>> AddNoteAsync(CreateNoteDTO createNoteDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<NoteDTO>>> GetAllNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<NoteDTO>>> GetDeletedNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<NoteDTO>> GetNoteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<NoteDTO>>> GetNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<NoteDTO>>> GetPrivateNotesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> HardDeleteNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> SoftDeleteNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<NoteDTO>> UpdateNoteAsync(CreateNoteDTO updateNoteDto)
        {
            throw new NotImplementedException();
        }
    }
}
