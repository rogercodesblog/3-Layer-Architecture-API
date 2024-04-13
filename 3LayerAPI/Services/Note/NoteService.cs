using _3LayerAPI.DTOs.Note;
using _3LayerAPI.Repository.Note;
using _3LayerAPI.ServiceResponder;
using AutoMapper;

namespace _3LayerAPI.Services.Note
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepo;
        private readonly IMapper _mapper;

        public NoteService(INoteRepository noteRepo, IMapper mapper)
        {
            _noteRepo = noteRepo;
            _mapper = mapper;
        }

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
