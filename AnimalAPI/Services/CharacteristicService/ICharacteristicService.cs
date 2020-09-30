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
        Task<ServiceResponse<List<GetCharacteristicDto>>> CreateContactCharacteristic(CreateCharacteristicDto newCharacteristic);

        // Read
        Task<ServiceResponse<List<GetCharacteristicDto>>> GetAllContactCharacteristics();

        Task<ServiceResponse<GetCharacteristicDto>> GetContactCharacteristicById(int id);

        // Update
        Task<ServiceResponse<GetCharacteristicDto>> UpdateContactCharacteristic(UpdatedCharacteristicDto updatedCharacteristic);

        // Delete
        Task<ServiceResponse<List<GetCharacteristicDto>>> DeleteContactCharacteristic(int id);
    }
}
