using AnimalAPI.Models.Dtos.Characteristics;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.CharacteristicService
{
    public interface ICharacteristicService
    {
        // Create
        Task<ServiceResponse<List<GetCharacteristicDto>>> CreateCharacteristic(CreateCharacteristicDto newCharacteristic);

        // Read
        Task<ServiceResponse<List<GetCharacteristicDto>>> GetAllCharacteristics();

        Task<ServiceResponse<GetCharacteristicDto>> GetCharacteristicById(int id);

        // Update
        Task<ServiceResponse<GetCharacteristicDto>> UpdateCharacteristic(UpdatedCharacteristicDto updatedCharacteristic);

        // Delete
        Task<ServiceResponse<List<GetCharacteristicDto>>> DeleteCharacteristic(int id);
    }
}
