
using AnimalAPI.Services.ContactNoteService;
using AnimalAPI.Models;
using AnimalAPI.Models.Dtos;
using AnimalAPI.Models.Dtos.Character;
using AnimalAPI.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimalAPI.Models.Dtos.Notes;

namespace AnimalAPI.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class ContactNoteController : ControllerBase
    {
        private readonly IContactNoteService _ContactNoteService;

        public ContactNoteController(IContactNoteService ContactNoteService)
        {
            _ContactNoteService = ContactNoteService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactNote(CreateNoteDto newNote)
        {
            return Ok(await _ContactNoteService.CreateContactNote(newNote));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ContactNoteService.GetAllContactNotes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _ContactNoteService.GetContactNoteById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContactNote(UpdatedNoteDto updatedContactNote)
        {
            ServiceResponse<GetNoteDto> response = await _ContactNoteService.UpdateContactNote(updatedContactNote);

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
            ServiceResponse<List<GetNoteDto>> response = await _ContactNoteService.DeleteContactNote(id);
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
