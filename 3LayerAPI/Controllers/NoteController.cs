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
        public async Task<ActionResult> GetNotes()
        {
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<ActionResult> GetAllNotes()
        {
            var notes = await _noteService.GetAllNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<ActionResult> GetDeletedNotes()
        {
            var notes = await _noteService.GetDeletedNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NoteDTO>))]
        public async Task<ActionResult> GetPrivateNotes()
        {
            var notes = await _noteService.GetPrivateNotesAsync();
            return Ok(notes);
        }

        [HttpGet("/[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDTO>> GetNoteById(int id)
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NoteDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoteDTO>> CreateNote([FromBody] CreateNoteDTO createNoteDTO)
        {
            if(createNoteDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var _newNote = await _noteService.AddNoteAsync(createNoteDTO);

            if (_newNote.Success == false || _newNote.Message == "Exist")
            {
                return Ok(_newNote);
            }
            if (_newNote.Success == false || _newNote.Message == "RepositoryError")
            {
                ModelState.AddModelError("", $"Some thing went wrong in respository layer when adding company {createNoteDTO}");
                return StatusCode(500, ModelState);
            }
            if (_newNote.Success == false || _newNote.Message == "Error")
            {
                ModelState.AddModelError("", $"Some thing went wrong in service layer when adding company {createNoteDTO}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNoteById", new { id = _newNote.Data.Id }, _newNote);
        }

    }
}
