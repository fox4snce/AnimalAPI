using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.BreedingRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordService
{
    public interface IBreedingRecordService
    {
        // Create
        Task<ServiceResponse<List<GetBreedingRecordDto>>> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord);

        // Read
        Task<ServiceResponse<List<GetBreedingRecordDto>>> GetAll();

        Task<ServiceResponse<GetBreedingRecordDto>> GetBreedingRecordById(int id);

        // Update
        Task<ServiceResponse<GetBreedingRecordDto>> UpdateBreedingRecord(UpdatedBreedingRecordDto updatedBreedingRecord);

        //Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
