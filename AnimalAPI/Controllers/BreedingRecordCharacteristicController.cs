using AnimalAPI.Models.Dtos.BreedingRecordCharacteristic;
using AnimalAPI.Models.Util;
using AnimalAPI.Services.BreedingRecordCharacteristicService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class BreedingRecordCharacteristicController : ControllerBase
    {
        private readonly IBreedingRecordCharacteristicService _breedingRecordCharacteristicService;

        public BreedingRecordCharacteristicController(IBreedingRecordCharacteristicService breedingRecordCharacteristicService)
        {
            _breedingRecordCharacteristicService = breedingRecordCharacteristicService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBreedingRecord(CreateBreedingRecordCharacteristicDto newBreedingRecordCharacteristic)
        {
            return Ok(await _breedingRecordCharacteristicService.CreateBreedingRecordCharacteristic(newBreedingRecordCharacteristic));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetBreedingRecordCharacteristicDto>> response = await _breedingRecordCharacteristicService.DeleteBreedingRecordCharacteristic(id);
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
