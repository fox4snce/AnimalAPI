
using AnimalAPI.Services.NoteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;

namespace AnimalAPI.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _NoteService;

        public NoteController(INoteService NoteService)
        {
            _NoteService = NoteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote(CreateNoteDto newNote)
        {
            return Ok(await _NoteService.CreateNote(newNote));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _NoteService.GetAllNotes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _NoteService.GetNoteById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote(UpdatedNoteDto updatedNote)
        {
            ServiceResponse<GetNoteDto> response = await _NoteService.UpdateNote(updatedNote);

            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetNoteDto>> response = await _NoteService.DeleteNote(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            else
            {
                return Ok(response);
            }
        }


    }
}
