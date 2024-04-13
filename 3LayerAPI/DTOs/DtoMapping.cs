using AutoMapper;

namespace _3LayerAPI.DTOs
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            CreateMap<Models.Note, Note.NoteDTO>().ReverseMap();
        }
    }
}
