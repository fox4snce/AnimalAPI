using AnimalAPI.Services.BreedingRecordNoteService;
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
    public class BreedingRecordNoteController : ControllerBase
    {
        private readonly IBreedingRecordNoteService _BreedingRecordNoteService;

        public BreedingRecordNoteController(IBreedingRecordNoteService BreedingRecordNoteService)
        {
            _BreedingRecordNoteService = BreedingRecordNoteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreedingRecordNote(CreateNoteDto newNote)
        {
            return Ok(await _BreedingRecordNoteService.CreateBreedingRecordNote(newNote));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _BreedingRecordNoteService.GetAllBreedingRecordNotes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _BreedingRecordNoteService.GetBreedingRecordNoteById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBreedingRecordNote(UpdatedNoteDto updatedBreedingRecordNote)
        {
            ServiceResponse<GetNoteDto> response = await _BreedingRecordNoteService.UpdateBreedingRecordNote(updatedBreedingRecordNote);

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
            ServiceResponse<List<GetNoteDto>> response = await _BreedingRecordNoteService.DeleteBreedingRecordNote(id);
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
