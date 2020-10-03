using AnimalAPI.Models.Dtos.Characteristics;
using AnimalAPI.Models.Util;
using AnimalAPI.Services.CharacteristicService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class CharacteristicController : ControllerBase
    {
        private readonly ICharacteristicService _characteristicService;

        public CharacteristicController(ICharacteristicService CharacteristicService)
        {
            _characteristicService = CharacteristicService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCharacteristic(CreateCharacteristicDto newCharacteristic)
        {
            return Ok(await _characteristicService.CreateCharacteristic(newCharacteristic));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characteristicService.GetAllCharacteristics());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characteristicService.GetCharacteristicById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacteristic(UpdatedCharacteristicDto updatedCharacteristic)
        {
            ServiceResponse<GetCharacteristicDto> response = await _characteristicService.UpdateCharacteristic(updatedCharacteristic);

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
            ServiceResponse<List<GetCharacteristicDto>> response = await _characteristicService.DeleteCharacteristic(id);
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
