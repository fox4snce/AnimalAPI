﻿using AnimalAPI.Data;
using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Notes;
using AnimalAPI.Models.Util;
using AnimalAPI.Services.NoteService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnimalAPI.Services.NoteService
{
    public class NoteService : INoteService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NoteService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        private string GetUserRole() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);


        public async Task<ServiceResponse<List<GetNoteDto>>> CreateNote(CreateNoteDto newNote)
        {
            // Response
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();

            // Map to Note
            Note note = _mapper.Map<Note>(newNote);

            // Set the note's user based on Id
            note.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == GetUserId());

            note.BreedingRecordId = newNote.BreedingRecordId;
            note.ContactId = newNote.ContactId;

            note.Title = newNote.Title;
            note.Body = newNote.Body;

            // Save
            await _context.Notes.AddAsync(note);
            await _context.SaveChangesAsync();

            // Return all the notes
            serviceResponse.Data = await GetAllRecords();

            return serviceResponse;
        }

        

        public async Task<ServiceResponse<List<GetNoteDto>>> DeleteNote(int id)
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            string UserRole = GetUserRole();

            try
            {
                
                Note Note = await _context.Notes.FirstAsync(c => c.Id == id && (c.User.Id == GetUserId() || UserRole.Equals("Admin")));

                if (Note != null)
                {
                    _context.Notes.Remove(Note);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Notes.Where(c => c.User.Id == GetUserId()).Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Note not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetNoteDto>>> GetAllNotes()
        {
            ServiceResponse<List<GetNoteDto>> serviceResponse = new ServiceResponse<List<GetNoteDto>>();
            serviceResponse.Data = await GetAllRecords();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> GetNoteById(int id)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            string UserRole = GetUserRole();

            Note note = UserRole.Equals("Admin") ?
                await _context.Notes
                .FirstOrDefaultAsync(c => c.Id == id) :
            await _context.Notes
                .FirstOrDefaultAsync(c => c.Id == id && c.User.Id == GetUserId());

            serviceResponse.Data = _mapper.Map<GetNoteDto>(note);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetNoteDto>> UpdateNote(UpdatedNoteDto updatedNote)
        {
            ServiceResponse<GetNoteDto> serviceResponse = new ServiceResponse<GetNoteDto>();

            string UserRole = GetUserRole();

            try
            {
                Note note = await _context.Notes.Include(c => c.User).AsNoTracking().FirstOrDefaultAsync(c => c.Id == updatedNote.Id);

                if (note.User.Id == GetUserId() || UserRole.Equals("Admin"))
                {
                    note.Medical = updatedNote.Medical;
                    note.Title = updatedNote.Title;
                    note.Body = updatedNote.Body;

                    note.Edited = DateTime.Now;

                    _context.Notes.Update(note);
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

            List<Note> records = UserRole.Equals("Admin") ?
                await _context.Notes
                .ToListAsync() :
                await _context.Notes
                .Where(c => c.User.Id == GetUserId()).ToListAsync();

            return records.Select(c => _mapper.Map<GetNoteDto>(c)).ToList();
        }
    }
}
