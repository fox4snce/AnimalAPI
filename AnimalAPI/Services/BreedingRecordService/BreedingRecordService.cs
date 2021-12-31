using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Util;
using AnimalAPI.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordService
{
    public class BreedingRecordService : IBreedingRecordService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BreedingRecordService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        private async Task<List<GetBreedingRecordDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<BreedingRecord> records = UserRole.Equals("Admin") ?
                await _context.BreedingRecords
                .Include(br => br.Owner)
                .Include(br => br.Breeder)
                .Include(br => br.BirthLitter)
                .Include(br => br.Notes)
                .Include(br => br.BreedingRecordCharacteristics).ThenInclude(brc => brc.Characteristic)
                .ToListAsync() :
                await _context.BreedingRecords
                .Include(br => br.Owner)
                .Include(br => br.Breeder)
                .Include(br => br.BirthLitter)
                .Include(br => br.Notes)
                .Include(br => br.BreedingRecordCharacteristics).ThenInclude(brc => brc.Characteristic)
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetBreedingRecordDto>(c)).ToList();
        }

        public async Task<ServiceResponse<List<GetBreedingRecordDto>>> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord)
        {
            ServiceResponse<List<GetBreedingRecordDto>> serviceResponse = new ServiceResponse<List<GetBreedingRecordDto>>();
            BreedingRecord record = _mapper.Map<BreedingRecord>(newBreedingRecord);
            record.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            record.Owner = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == newBreedingRecord.OwnerId);
            record.Breeder = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == newBreedingRecord.BreederId);
            record.BirthLitter = await _context.Litters.FirstOrDefaultAsync(c => c.Id == newBreedingRecord.BirthLitterId);
            record.Sex = newBreedingRecord.Sex == 1 ? record.Sex = Gender.Male : record.Sex = Gender.Female;
            

            await _context.BreedingRecords.AddAsync(record);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBreedingRecordDto>>> GetAllBreedingRecords()
        {
            ServiceResponse<List<GetBreedingRecordDto>> serviceResponse = new ServiceResponse<List<GetBreedingRecordDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        

        public async Task<ServiceResponse<GetBreedingRecordDto>> GetBreedingRecordById(int id)
        {
            ServiceResponse<GetBreedingRecordDto> serviceResponse = new ServiceResponse<GetBreedingRecordDto>();
            
            string UserRole = GetUserRole();

            BreedingRecord record = UserRole.Equals("Admin") ?
                await _context.BreedingRecords
                .Include(br => br.Owner)
                .Include(br => br.Breeder)
                .Include(br => br.BirthLitter)
                .Include(br => br.Notes)
                .Include(br => br.BreedingRecordCharacteristics).ThenInclude(brc => brc.Characteristic)
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.BreedingRecords
                .Include(br => br.Owner)
                .Include(br => br.Breeder)
                .Include(br => br.BirthLitter)
                .Include(br => br.Notes)
                .Include(br => br.BreedingRecordCharacteristics).ThenInclude(brc => brc.Characteristic)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetBreedingRecordDto>(record);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBreedingRecordDto>> UpdateBreedingRecord(UpdatedBreedingRecordDto updatedBreedingRecord)
        {
            ServiceResponse<GetBreedingRecordDto> serviceResponse = new ServiceResponse<GetBreedingRecordDto>();

            try
            {
                BreedingRecord breedingRecord = await _context.BreedingRecords.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedBreedingRecord.Id);

                //BreedingRecord mappedUpdated = _mapper.Map<BreedingRecord>(updatedBreedingRecord);

                if (breedingRecord.User.Id == GetUserId())
                {
                    //breedingRecord = Utility.Util.CloneJson<BreedingRecord>(mappedUpdated);

                    breedingRecord.Name = updatedBreedingRecord.Name;
                    breedingRecord.Owner = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == updatedBreedingRecord.OwnerId);
                    breedingRecord.Breeder = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == updatedBreedingRecord.BreederId);
                    
                    breedingRecord.BirthLitter = await _context.Litters.FirstOrDefaultAsync(c => c.Id == updatedBreedingRecord.BirthLitterId);
                    breedingRecord.Sex = updatedBreedingRecord.Sex == 1 ? Gender.Male : Gender.Female;
                    breedingRecord.Public = updatedBreedingRecord.Public;
                    breedingRecord.Birthday = updatedBreedingRecord.Birthday;
                    breedingRecord.DateOfAcquisition = updatedBreedingRecord.DateOfAcquisition;

                    _context.BreedingRecords.Update(breedingRecord);
                    
                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetBreedingRecordDto>(breedingRecord);
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

        public async Task<ServiceResponse<List<GetBreedingRecordDto>>> DeleteBreedingRecord(int id)
        {
            ServiceResponse<List<GetBreedingRecordDto>> serviceResponse = new ServiceResponse<List<GetBreedingRecordDto>>();

            try
            {
                BreedingRecord breedingRecord = await _context.BreedingRecords.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (breedingRecord != null)
                {
                    _context.BreedingRecords.Remove(breedingRecord);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.BreedingRecords.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetBreedingRecordDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "BreedingRecord not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
