
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Dtos.Contacts;
using AnimalAPI.Models.Dtos.Litters;
using AnimalAPI.Models.Dtos.Notes;
using AutoMapper;
using System.Linq;

namespace AnimalAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Breeding Records
            CreateMap<BreedingRecord, GetBreedingRecordDto>();
            CreateMap<CreateBreedingRecordDto, BreedingRecord>();
            CreateMap<UpdatedBreedingRecordDto, BreedingRecord>();

            // Litters
            CreateMap<Litter, GetLitterDto>();

            // Contacts
            CreateMap<Contact, GetContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdatedContactDto, Contact>();

            // BreedingRecordNotes
            CreateMap<BreedingRecordNote, GetNoteDto>();
            CreateMap<CreateNoteDto, BreedingRecordNote>();
            CreateMap<UpdatedNoteDto, BreedingRecordNote>();

            // ContactNotes
            CreateMap<ContactNote, GetNoteDto>();
            CreateMap<CreateNoteDto, ContactNote>();
            CreateMap<UpdatedNoteDto, ContactNote>();


        }
    }
}
