using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Services.BreedingRecordService;
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
    public class BreedingRecordController: ControllerBase
    {
        private readonly IBreedingRecordService _breedingRecordService;

        public BreedingRecordController(IBreedingRecordService breedingRecordService)
        {
            _breedingRecordService = breedingRecordService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord)
        {
            return Ok(await _breedingRecordService.CreateBreedingRecord(newBreedingRecord));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _breedingRecordService.GetAllBreedingRecords());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _breedingRecordService.GetBreedingRecordById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBreedingRecord(UpdatedBreedingRecordDto updatedBreedingRecord)
        {
            ServiceResponse<GetBreedingRecordDto> response = await _breedingRecordService.UpdateBreedingRecord(updatedBreedingRecord);

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
            ServiceResponse<List<GetBreedingRecordDto>> response = await _breedingRecordService.DeleteBreedingRecord(id);
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
