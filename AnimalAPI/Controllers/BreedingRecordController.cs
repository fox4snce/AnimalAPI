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
            return Ok(await _breedingRecordService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _breedingRecordService.GetBreedingRecordById(id));
        }


    }
}
