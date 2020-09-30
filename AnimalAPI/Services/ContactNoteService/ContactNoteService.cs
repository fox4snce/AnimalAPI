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

namespace AnimalAPI.Services.ContactNoteService
{
    public class ContactNoteService : IContactNoteService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactNoteService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


        public async Task<ServiceResponse<List<GetNoteDto>>> CreateContactNote(CreateNoteDto newNote)
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            ContactNote note = _mapper.Map<ContactNote>(newNote);
            note.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());
            note.ContactId = newNote.ReferenceId;
            await _context.ContactNotes.AddAsync(note);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> DeleteContactNote(int id)
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();

            try
            {
                ContactNote ContactNote = await _context.ContactNotes.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (ContactNote != null)
                {
                    _context.ContactNotes.Remove(ContactNote);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.ContactNotes.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "ContactNote not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> GetAllContactNotes()
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> GetContactNoteById(int id)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            string UserRole = GetUserRole();

            ContactNote note = UserRole.Equals("Admin") ?
                await _context.ContactNotes
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.ContactNotes
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetNoteDto>(note);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> UpdateContactNote(UpdatedNoteDto updatedNote)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            try
            {
                ContactNote note = await _context.ContactNotes.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedNote.Id);

                ContactNote mappedUpdated = _mapper.Map<ContactNote>(updatedNote);

                mappedUpdated.ContactId = updatedNote.ReferenceId;
                mappedUpdated.Edited = DateTime.Now;

                if (note.User.Id == GetUserId())
                {
                    note = Utility.Util.CloneJson<ContactNote>(mappedUpdated);


                    _context.ContactNotes.Update(note);

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

            List<ContactNote> records = UserRole.Equals("Admin") ?
                await _context.ContactNotes
                .ToListAsync() :
                await _context.ContactNotes
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
        }
    }
}
