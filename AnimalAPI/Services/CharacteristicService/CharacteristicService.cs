using AnimalAPI.Models.Dtos.Characteristics;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.CharacteristicService
{
    public class CharacteristicService : ICharacteristicService
    {
        public Task<ServiceResponse<List<GetCharacteristicDto>>> CreateContactCharacteristic(CreateCharacteristicDto newCharacteristic)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetCharacteristicDto>>> DeleteContactCharacteristic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetCharacteristicDto>>> GetAllContactCharacteristics()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacteristicDto>> GetContactCharacteristicById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetCharacteristicDto>> UpdateContactCharacteristic(UpdatedCharacteristicDto updatedCharacteristic)
        {
            throw new NotImplementedException();
        }
    }
}
