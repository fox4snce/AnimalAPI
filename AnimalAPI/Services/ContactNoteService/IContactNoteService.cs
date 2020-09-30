using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.ContactNoteService
{
    public interface IContactNoteService
    {
        // Create
        Task<ServiceResponse<List<GetNoteDto>>> CreateContactNote(CreateNoteDto newNote);

        // Read
        Task<ServiceResponse<List<GetNoteDto>>> GetAllContactNotes();

        Task<ServiceResponse<GetNoteDto>> GetContactNoteById(int id);

        // Update
        Task<ServiceResponse<GetNoteDto>> UpdateContactNote(UpdatedNoteDto updatedNote);

        // Delete
        Task<ServiceResponse<List<GetNoteDto>>> DeleteContactNote(int id);
    }
}
