using _3LayerAPI.DTOs.Note;
using _3LayerAPI.Repository.Note;
using _3LayerAPI.ServiceResponder;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<ServiceResponse<NoteDTO>> AddNoteAsync(CreateNoteDTO createNoteDto)
        {
            ServiceResponse<NoteDTO> _response = new ServiceResponse<NoteDTO>();
            try
            {

                if (await _noteRepo.NoteExistAsync(createNoteDto.Title))
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.Message = "A Note with that title already exists";
                    return _response;
                }

                Models.Note newnote = new Models.Note()
                {
                    Title = createNoteDto.Title,
                    Content = createNoteDto.Content,
                    DateCreated = DateTimeOffset.UtcNow,
                    IsDeleted = false,
                    IsPrivate = createNoteDto.IsPrivate
                };

                if(!await _noteRepo.CreateNoteAsync(newnote)) 
                {
                    _response.Success = false;
                    _response.Data = null;
                    _response.Message = "There was an error in Repository";
                    return _response;
                }

                _response.Success = true;
                _response.Data = _mapper.Map<NoteDTO>(newnote);
                _response.Message = "The new note was created successfully";
                
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "There was an internal server error, please try again.";
                _response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }
            return _response;
        }

        public async Task<ServiceResponse<List<NoteDTO>>> GetAllNotesAsync()
        {
            ServiceResponse<List<NoteDTO>> _response = new ServiceResponse<List<NoteDTO>>();
            try
            {
                var noteList = await _noteRepo.GetAllNotesAsync();
                var noteDtoList = new List<NoteDTO>();
                foreach (var note in noteList) 
                {
                    noteDtoList.Add(_mapper.Map<NoteDTO>(note));
                }
                _response.Success = true;
                _response.Message = "OK";
                _response.Data = noteDtoList;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string>() { Convert.ToString(ex.Message) };
            }
            return _response;
        }

        public async Task<ServiceResponse<List<NoteDTO>>> GetDeletedNotesAsync()
        {
            ServiceResponse<List<NoteDTO>> _response = new ServiceResponse<List<NoteDTO>>();
            try
            {
                var noteList = await _noteRepo.GetDeletedNotesAsync();
                var noteDtoList = new List<NoteDTO>();
                foreach (var note in noteList)
                {
                    noteDtoList.Add(_mapper.Map<NoteDTO>(note));
                }
                _response.Success = true;
                _response.Message = "OK";
                _response.Data = noteDtoList;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string>() { Convert.ToString(ex.Message) };
            }
            return _response;
        }

        public async Task<ServiceResponse<NoteDTO>> GetNoteByIdAsync(int id)
        {
            ServiceResponse<NoteDTO> _response = new ServiceResponse<NoteDTO>();
            try
            {
                var _note = await _noteRepo.GetNoteByIdAsync(id);

                if(_note == null)
                {
                    _response.Success = false;
                    _response.Message = "The note was not found";
                    return _response;
                }
                var _noteDto = _mapper.Map<NoteDTO>(_note);

                _response.Success = true;
                _response.Message = "Ok";
                _response.Data = _noteDto;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string>() { Convert.ToString(ex.Message) };
            }
            return _response;
        }

        public async Task<ServiceResponse<List<NoteDTO>>> GetNotesAsync()
        {
            ServiceResponse<List<NoteDTO>> _response = new ServiceResponse<List<NoteDTO>>();
            try
            {
                var noteList = await _noteRepo.GetNotesAsync();
                var noteDtoList = new List<NoteDTO>();
                foreach (var note in noteList)
                {
                    noteDtoList.Add(_mapper.Map<NoteDTO>(note));
                }
                _response.Success = true;
                _response.Message = "OK";
                _response.Data = noteDtoList;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string>() { Convert.ToString(ex.Message) };
            }
            return _response;
        }

        public async Task<ServiceResponse<List<NoteDTO>>> GetPrivateNotesAsync()
        {
            ServiceResponse<List<NoteDTO>> _response = new ServiceResponse<List<NoteDTO>>();
            try
            {
                var noteList = await _noteRepo.GetPrivateNotesAsync();
                var noteDtoList = new List<NoteDTO>();
                foreach (var note in noteList)
                {
                    noteDtoList.Add(_mapper.Map<NoteDTO>(note));
                }
                _response.Success = true;
                _response.Message = "OK";
                _response.Data = noteDtoList;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Data = null;
                _response.Message = "Error";
                _response.ErrorMessages = new List<string>() { Convert.ToString(ex.Message) };
            }
            return _response;
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
