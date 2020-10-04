using AnimalAPI.Models.Dtos.BreedingRecordCharacteristic;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordCharacteristicService
{
    public interface IBreedingRecordCharacteristicService
    {
        // Create
        Task<ServiceResponse<GetBreedingRecordDto>> CreateBreedingRecordCharacteristic(CreateBreedingRecordCharacteristicDto newBreedingRecordCharacteristic);

        // Read
        Task<ServiceResponse<List<GetBreedingRecordCharacteristicDto>>> GetAllBreedingRecordCharacteristics();

        Task<ServiceResponse<GetBreedingRecordCharacteristicDto>> GetBreedingRecordCharacteristicById(int id);

        // Update
        Task<ServiceResponse<GetBreedingRecordCharacteristicDto>> UpdateBreedingRecordCharacteristic(UpdatedBreedingRecordCharacteristicDto updatedBreedingRecordCharacteristic);

        // Delete
        Task<ServiceResponse<List<GetBreedingRecordCharacteristicDto>>> DeleteBreedingRecordCharacteristic(int id);
    }
}
