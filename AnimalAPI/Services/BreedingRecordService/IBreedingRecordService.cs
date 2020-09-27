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
        Task<ServiceResponse<List<GetBreedingRecordDto>>> GetAll();

        Task<ServiceResponse<GetBreedingRecordDto>> GetBreedingRecordById(int id);

        //Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<List<GetBreedingRecordDto>>> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord);

        //Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdatedCharacterDto updatedCharacter);

        //Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}
