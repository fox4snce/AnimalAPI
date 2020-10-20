using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Contacts;
using AnimalAPI.Models.Util;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.ContactService
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContactService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

        public async Task<ServiceResponse<List<GetContactDto>>> CreateContact(CreateContactDto newContact)
        {
            ServiceResponse<List<GetContactDto>> serviceResponse = new ServiceResponse<List<GetContactDto>>();
            Contact record = _mapper.Map<Contact>(newContact);
            record.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            await _context.Contacts.AddAsync(record);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> DeleteContact(int id)
        {
            ServiceResponse<List<GetContactDto>> serviceResponse = new ServiceResponse<List<GetContactDto>>();

            try
            {
                Contact Contact = await _context.Contacts.FirstAsync(c => c.Id == id && c.User.Id == GetUserId());

                if (Contact != null)
                {
                    _context.Contacts.Remove(Contact);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Contacts.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetContactDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Contact not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetContactDto>>> GetAllContacts()
        {
            ServiceResponse<List<GetContactDto>> serviceResponse = new ServiceResponse<List<GetContactDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> GetContactById(int id)
        {
            ServiceResponse<GetContactDto> serviceResponse = new ServiceResponse<GetContactDto>();

            string UserRole = GetUserRole();

            Contact record = UserRole.Equals("Admin") ?
                await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetContactDto>(record);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetContactDto>> UpdateContact(UpdatedContactDto updatedContact)
        {
            ServiceResponse<GetContactDto> serviceResponse = new ServiceResponse<GetContactDto>();

            try
            {
                Contact contact = await _context.Contacts.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedContact.Id);

                Contact mappedUpdated = _mapper.Map<Contact>(updatedContact);

                if (contact.User.Id == GetUserId())
                {

                    contact.FirstName = (updatedContact.FirstName != null) ? updatedContact.FirstName : contact.FirstName;
                    contact.LastName = (updatedContact.LastName != null) ? updatedContact.LastName : contact.LastName;
                    contact.Email = (updatedContact.Email != null) ? updatedContact.Email : contact.Email;
                    contact.Type = (updatedContact.Type != ContactType.Null) ? updatedContact.Type : contact.Type;
                    contact.Address = (updatedContact.Address != null) ? updatedContact.Address : contact.Address;
                    contact.Address2 = (updatedContact.Address2 != null) ? updatedContact.Address2 : contact.Address2;
                    contact.City = (updatedContact.City != null) ? updatedContact.City : contact.City;
                    contact.State = (updatedContact.State != null) ? updatedContact.State : contact.State;
                    contact.ZipCode = (updatedContact.ZipCode != null) ? updatedContact.ZipCode : contact.ZipCode;
                    contact.Country = (updatedContact.Country != null) ? updatedContact.Country : contact.Country;
                    contact.PhoneNumber = (updatedContact.PhoneNumber != null) ? updatedContact.PhoneNumber : contact.PhoneNumber;
                    contact.CellPhone = (updatedContact.CellPhone != null) ? updatedContact.CellPhone : contact.CellPhone;


                    _context.Contacts.Update(contact);

                    await _context.SaveChangesAsync();


                    serviceResponse.Data = _mapper.Map<GetContactDto>(contact);
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

        private async Task<List<GetContactDto>> GetAllRecords()
        {
            string UserRole = GetUserRole();

            List<Contact> records = UserRole.Equals("Admin") ?
                await _context.Contacts
                .Include(br => br.Notes)
                .ToListAsync() :
                await _context.Contacts
                .Include(br => br.Notes)
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetContactDto>(c)).ToList();
        }
    }
}
