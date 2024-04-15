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

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<IActionResult> GetNotesAsync()
        {
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<IActionResult> GetAllNotesAsync()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<IActionResult> GetDeletedNotesAsync()
        {
            var notes = await _noteService.GetDeletedNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<IActionResult> GetPrivateNotesAsync()
        {
            var notes = await _noteService.GetPrivateNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> GetNoteByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(id);
            }

            var note = await _noteService.GetNoteByIdAsync(id);

            if(note.Data == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

    }
}
