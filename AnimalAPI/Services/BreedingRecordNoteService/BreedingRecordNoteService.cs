using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordNoteService
{
    public class BreedingRecordNoteService : IBreedingRecordNoteService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BreedingRecordNoteService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


        public async Task<ServiceResponse<List<GetNoteDto>>> CreateBreedingRecordNote(CreateNoteDto newNote)
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            BreedingRecordNote note = _mapper.Map<BreedingRecordNote>(newNote);
            note.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            note.BreedingRecordId = newNote.ReferenceId;
            await _context.BreedingRecordNotes.AddAsync(note);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> DeleteBreedingRecordNote(int id)
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();

            try
            {
                BreedingRecordNote BreedingRecordNote = await _context.BreedingRecordNotes.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (BreedingRecordNote != null)
                {
                    _context.BreedingRecordNotes.Remove(BreedingRecordNote);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.BreedingRecordNotes.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "BreedingRecordNote not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> GetAllBreedingRecordNotes()
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> GetBreedingRecordNoteById(int id)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            string UserRole = GetUserRole();

            BreedingRecordNote note = UserRole.Equals("Admin") ?
                await _context.BreedingRecordNotes
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.BreedingRecordNotes
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetNoteDto>(note);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> UpdateBreedingRecordNote(UpdatedNoteDto updatedNote)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            try
            {
                BreedingRecordNote note = await _context.BreedingRecordNotes.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedNote.Id);

                BreedingRecordNote mappedUpdated = _mapper.Map<BreedingRecordNote>(updatedNote);

                mappedUpdated.BreedingRecordId = updatedNote.ReferenceId;
                mappedUpdated.Edited = DateTime.Now;

                if (note.User.Id == GetUserId())
                {
                    note = Utility.Util.CloneJson<BreedingRecordNote>(mappedUpdated);


                    _context.BreedingRecordNotes.Update(note);

                    await _context.SaveChangesAsync();


                    serviceResponse.Data = _mapper.Map<GetNoteDto>(note);
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

        private async Task<List<GetNoteDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<BreedingRecordNote> records = UserRole.Equals("Admin") ?
                await _context.BreedingRecordNotes
                .ToListAsync() :
                await _context.BreedingRecordNotes
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
        }
    }
}
