using AnimalAPI.Data;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Characteristics;
using AnimalAPI.Models.Util;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.CharacteristicService
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacteristicService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


        public async Task<ServiceResponse<List<GetCharacteristicDto>>> CreateCharacteristic(CreateCharacteristicDto newCharacteristic)
        {
            ServiceResponse<List<GetCharacteristicDto>> serviceResponse = new ServiceResponse<List<GetCharacteristicDto>>();
            Characteristic Characteristic = _mapper.Map<Characteristic>(newCharacteristic);
            Characteristic.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            await _context.Characteristics.AddAsync(Characteristic);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacteristicDto>>> DeleteCharacteristic(int id)
        {
            ServiceResponse<List<GetCharacteristicDto>> serviceResponse = new ServiceResponse<List<GetCharacteristicDto>>();

            try
            {
                Characteristic Characteristic = await _context.Characteristics.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (Characteristic != null)
                {
                    _context.Characteristics.Remove(Characteristic);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Characteristics.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetCharacteristicDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Characteristic not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacteristicDto>>> GetAllCharacteristics()
        {
            ServiceResponse<List<GetCharacteristicDto>> serviceResponse = new ServiceResponse<List<GetCharacteristicDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacteristicDto>> GetCharacteristicById(int id)
        {
            ServiceResponse<GetCharacteristicDto> serviceResponse = new ServiceResponse<GetCharacteristicDto>();

            string UserRole = GetUserRole();

            Characteristic Characteristic = UserRole.Equals("Admin") ?
                await _context.Characteristics
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.Characteristics
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetCharacteristicDto>(Characteristic);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacteristicDto>> UpdateCharacteristic(UpdatedCharacteristicDto updatedCharacteristic)
        {
            ServiceResponse<GetCharacteristicDto> serviceResponse = new ServiceResponse<GetCharacteristicDto>();

            try
            {
                Characteristic Characteristic = await _context.Characteristics.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedCharacteristic.Id);

                Characteristic mappedUpdated = _mapper.Map<Characteristic>(updatedCharacteristic);


                if (Characteristic.User.Id == GetUserId())
                {
                    Characteristic = Utility.Util.CloneJson<Characteristic>(mappedUpdated);


                    _context.Characteristics.Update(Characteristic);

                    await _context.SaveChangesAsync();


                    serviceResponse.Data = _mapper.Map<GetCharacteristicDto>(Characteristic);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Record not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        private async Task<List<GetCharacteristicDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<Characteristic> records = UserRole.Equals("Admin") ?
                await _context.Characteristics
                .ToListAsync() :
                await _context.Characteristics
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetCharacteristicDto>(c)).ToList();
        }
    }
}
