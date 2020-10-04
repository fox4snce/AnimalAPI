using AnimalAPI.Models.Dtos.Litters;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.LitterService
{
    public interface ILitterService
    {
        // Create
        Task<ServiceResponse<List<GetLitterDto>>> CreateLitter(CreateLitterDto newLitter);

        // Read
        Task<ServiceResponse<List<GetLitterDto>>> GetAllLitters();

        Task<ServiceResponse<GetLitterDto>> GetLitterById(int id);

        // Update
        Task<ServiceResponse<GetLitterDto>> UpdateLitter(UpdatedLitterDto updatedLitter);

        // Delete
        Task<ServiceResponse<List<GetLitterDto>>> DeleteLitter(int id);
    }
}
