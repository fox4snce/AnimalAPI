using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Util;
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
        Task<ServiceResponse<List<GetBreedingRecordDto>>> GetAllBreedingRecords();

        Task<ServiceResponse<GetBreedingRecordDto>> GetBreedingRecordById(int id);

        // Update
        Task<ServiceResponse<GetBreedingRecordDto>> UpdateBreedingRecord(UpdatedBreedingRecordDto updatedBreedingRecord);

        // Delete
        Task<ServiceResponse<List<GetBreedingRecordDto>>> DeleteBreedingRecord(int id);
    }
}
