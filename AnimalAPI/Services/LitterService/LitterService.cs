using AnimalAPI.Data;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Litters;
using AnimalAPI.Models.Util;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.LitterService
{
    public class LitterService : ILitterService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LitterService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        private async Task<List<GetLitterDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<Litter> records = UserRole.Equals("Admin") ?
                await _context.Litters
                .Include(lit => lit.Breeder)
                .Include(lit => lit.Parents).ThenInclude(parents => parents.Parent)
                .Include(lit => lit.Siblings).ThenInclude(sibling => sibling.Sibling)
                .ToListAsync() :
                await _context.Litters
                .Include(lit => lit.Breeder)
                .Include(lit => lit.Parents).ThenInclude(parents => parents.Parent)
                .Include(lit => lit.Siblings).ThenInclude(sibling => sibling.Sibling)
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetLitterDto>(c)).ToList();
        }

        public async Task<ServiceResponse<List<GetLitterDto>>> CreateLitter(CreateLitterDto newLitter)
        {
            ServiceResponse<List<GetLitterDto>> serviceResponse = new ServiceResponse<List<GetLitterDto>>();
            Litter record = _mapper.Map<Litter>(newLitter);
            record.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            record.Breeder = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == newLitter.BreederId);

            await _context.Litters.AddAsync(record);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLitterDto>>> DeleteLitter(int id)
        {
            ServiceResponse<List<GetLitterDto>> serviceResponse = new ServiceResponse<List<GetLitterDto>>();

            try
            {
                Litter Litter = await _context.Litters.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (Litter != null)
                {
                    _context.Litters.Remove(Litter);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await GetAllRecords();

                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Litter not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLitterDto>>> GetAllLitters()
        {
            ServiceResponse<List<GetLitterDto>> serviceResponse = new ServiceResponse<List<GetLitterDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLitterDto>> GetLitterById(int id)
        {
            ServiceResponse<GetLitterDto> serviceResponse = new ServiceResponse<GetLitterDto>();

            string UserRole = GetUserRole();

            Litter record = UserRole.Equals("Admin") ?
                await _context.Litters
                .Include(lit => lit.Parents).ThenInclude(parents => parents.Parent)
                .Include(lit => lit.Siblings).ThenInclude(sibling => sibling.Sibling)
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.Litters
                .Include(lit => lit.Parents).ThenInclude(parents => parents.Parent)
                .Include(lit => lit.Siblings).ThenInclude(sibling => sibling.Sibling)
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetLitterDto>(record);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLitterDto>> UpdateLitter(UpdatedLitterDto updatedLitter)
        {
            ServiceResponse<GetLitterDto> serviceResponse = new ServiceResponse<GetLitterDto>();

            try
            {
                Litter Litter = await _context.Litters.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedLitter.Id);

                Litter mappedUpdated = _mapper.Map<Litter>(updatedLitter);

                if (Litter.User.Id == GetUserId())
                {
                    Litter = Utility.Util.CloneJson<Litter>(mappedUpdated);


                    _context.Litters.Update(Litter);

                    await _context.SaveChangesAsync();


                    serviceResponse.Data = _mapper.Map<GetLitterDto>(Litter);
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
    }
}
