using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.BreedingRecordNoteService
{
    public interface IBreedingRecordNoteService
    {
        // Create
        Task<ServiceResponse<List<GetNoteDto>>> CreateBreedingRecordNote(CreateNoteDto newNote);

        // Read
        Task<ServiceResponse<List<GetNoteDto>>> GetAllBreedingRecordNotes();

        Task<ServiceResponse<GetNoteDto>> GetBreedingRecordNoteById(int id);

        // Update
        Task<ServiceResponse<GetNoteDto>> UpdateBreedingRecordNote(UpdatedNoteDto updatedNote);

        // Delete
        Task<ServiceResponse<List<GetNoteDto>>> DeleteBreedingRecordNote(int id);
    }
}
