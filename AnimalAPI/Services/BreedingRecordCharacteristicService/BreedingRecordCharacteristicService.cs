using AnimalAPI.Data;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.BreedingRecordCharacteristic;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Util;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordCharacteristicService
{
    public class BreedingRecordCharacteristicService : IBreedingRecordCharacteristicService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BreedingRecordCharacteristicService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        

        public async Task<ServiceResponse<GetBreedingRecordDto>> CreateBreedingRecordCharacteristic(CreateBreedingRecordCharacteristicDto newBreedingRecordCharacteristic)
        {
            ServiceResponse<GetBreedingRecordDto> serviceResponse = new ServiceResponse<GetBreedingRecordDto>();

            try
            {
                BreedingRecord record = await _context.BreedingRecords
                    .Include(br => br.BreedingRecordCharacteristics).ThenInclude(br => br.Characteristic)
                    .FirstOrDefaultAsync(br => br.Id == newBreedingRecordCharacteristic.BreedingRecordId &&
                    br.User.Id == GetUserId());
                    
                if(record == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "BreedingRecord not found.";
                    return serviceResponse;
                }

                Characteristic characteristic = await _context.Characteristics
                    .FirstOrDefaultAsync(c => c.Id == newBreedingRecordCharacteristic.CharacteristicId);

                if(characteristic == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Characteristic not found.";
                    return serviceResponse;
                }

                BreedingRecordCharacteristic breedingRecordCharacteristic = new BreedingRecordCharacteristic
                {
                    BreedingRecord = record,
                    Characteristic = characteristic
                };

                await _context.BreedingRecordCharacteristics.AddAsync(breedingRecordCharacteristic);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetBreedingRecordDto>(record);
            } 
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBreedingRecordCharacteristicDto>>> DeleteBreedingRecordCharacteristic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetBreedingRecordCharacteristicDto>>> GetAllBreedingRecordCharacteristics()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetBreedingRecordCharacteristicDto>> GetBreedingRecordCharacteristicById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetBreedingRecordCharacteristicDto>> UpdateBreedingRecordCharacteristic(UpdatedBreedingRecordCharacteristicDto updatedBreedingRecordCharacteristic)
        {
            throw new NotImplementedException();
        }
    }
}
