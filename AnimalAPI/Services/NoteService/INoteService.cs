using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.NoteService
{
    public interface INoteService
    {
        // Create
        Task<ServiceResponse<List<GetNoteDto>>> CreateNote(CreateNoteDto newNote);

        // Read
        Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes();

        Task<ServiceResponse<GetNoteDto>> GetNoteById(int id);

        // Update
        Task<ServiceResponse<GetNoteDto>> UpdateNote(UpdatedNoteDto updatedNote);

        // Delete
        Task<ServiceResponse<List<GetNoteDto>>> DeleteNote(int id);
    }
}
