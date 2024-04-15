using _3LayerAPI.DTOs.Note;
using _3LayerAPI.Services.Note;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3LayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteservice)
        {
                _noteService = noteservice;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<IActionResult> GetNotesAsync()
        {
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }

    }
}
