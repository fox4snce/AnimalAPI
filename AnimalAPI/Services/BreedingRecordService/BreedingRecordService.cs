using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.BreedingRecords;
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

        public async Task<ServiceResponse<List<GetBreedingRecordDto>>> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord)
        {
            ServiceResponse<List<GetBreedingRecordDto>> serviceResponse = new ServiceResponse<List<GetBreedingRecordDto>>();
            BreedingRecord record = _mapper.Map<BreedingRecord>(newBreedingRecord);
            record.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.BreedingRecords.AddAsync(record);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBreedingRecordDto>>> GetAll()
        {
            ServiceResponse<List<GetBreedingRecordDto>> serviceResponse = new ServiceResponse<List<GetBreedingRecordDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        private async Task<List<GetBreedingRecordDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<BreedingRecord> records = UserRole.Equals("Admin") ?
                await _context.BreedingRecords
                .Include(br => br.BirthLitter)
                .ToListAsync() :
                await _context.BreedingRecords
                .Include(br => br.BirthLitter)
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetBreedingRecordDto>(c)).ToList();
        }

        public async Task<ServiceResponse<GetBreedingRecordDto>> GetBreedingRecordById(int id)
        {
            ServiceResponse<GetBreedingRecordDto> serviceResponse = new ServiceResponse<GetBreedingRecordDto>();
            
            string UserRole = GetUserRole();

            BreedingRecord record = UserRole.Equals("Admin") ?
                await _context.BreedingRecords
                .Include(br => br.BirthLitter)
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.BreedingRecords
                .Include(br => br.BirthLitter)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetBreedingRecordDto>(record);
            return serviceResponse;
        }
    }
}
