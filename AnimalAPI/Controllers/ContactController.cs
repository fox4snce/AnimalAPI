using AnimalAPI.Models.Dtos.Contacts;
using AnimalAPI.Services.ContactService;
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

namespace AnimalAPI.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto newContact)
        {
            return Ok(await _ContactService.CreateContact(newContact));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ContactService.GetAllContacts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _ContactService.GetContactById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdatedContactDto updatedContact)
        {
            ServiceResponse<GetContactDto> response = await _ContactService.UpdateContact(updatedContact);

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
            ServiceResponse<List<GetContactDto>> response = await _ContactService.DeleteContact(id);
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
