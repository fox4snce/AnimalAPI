using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Contacts;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.ContactService
{
    public interface IContactService
    {
        // Create
        Task<ServiceResponse<List<GetContactDto>>> CreateContact(CreateContactDto newContact);

        // Read
        Task<ServiceResponse<List<GetContactDto>>> GetAllContacts();

        Task<ServiceResponse<GetContactDto>> GetContactById(int id);

        // Update
        Task<ServiceResponse<GetContactDto>> UpdateContact(UpdatedContactDto updatedContact);

        // Delete
        Task<ServiceResponse<List<GetContactDto>>> DeleteContact(int id);
    }
}
