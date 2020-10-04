using AnimalAPI.Models.Dtos.Litters;
using AnimalAPI.Models.Util;
using AnimalAPI.Services.LitterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalAPI.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [ApiController]
    [Route("[controller]")]
    public class LitterController: ControllerBase
    {
        private readonly ILitterService _LitterService;

        public LitterController(ILitterService LitterService)
        {
            _LitterService = LitterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLitter(CreateLitterDto newLitter)
        {
            return Ok(await _LitterService.CreateLitter(newLitter));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _LitterService.GetAllLitters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _LitterService.GetLitterById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLitter(UpdatedLitterDto updatedLitter)
        {
            ServiceResponse<GetLitterDto> response = await _LitterService.UpdateLitter(updatedLitter);

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
            ServiceResponse<List<GetLitterDto>> response = await _LitterService.DeleteLitter(id);
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
