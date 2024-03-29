﻿
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.BreedingRecordCharacteristic;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Dtos.Characteristics;
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
            CreateMap<BreedingRecord, GetBreedingRecordDto>()
                .ForMember(dto => dto.Characteristics, br => br.MapFrom(br => br.BreedingRecordCharacteristics.Select(brc => brc.Characteristic)));
            CreateMap<CreateBreedingRecordDto, BreedingRecord>();
            CreateMap<UpdatedBreedingRecordDto, BreedingRecord>();

            // Litters
            CreateMap<Litter, GetLitterDto>()
                .ForMember(dto => dto.Parents, lit => lit.MapFrom(lit => lit.Parents.Select(pr => pr.Parent)))
                .ForMember(dto => dto.Siblings, lit => lit.MapFrom(lit => lit.Siblings.Select(sr => sr.Sibling)));
            CreateMap<CreateLitterDto, Litter>();
            CreateMap<UpdatedLitterDto, Litter>();

            // Contacts
            CreateMap<Contact, GetContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdatedContactDto, Contact>();
            CreateMap<GetContactDto, Contact>();

            

            // Notes
            CreateMap<Note, GetNoteDto>();
            CreateMap<CreateNoteDto, Note>();
            CreateMap<UpdatedNoteDto, Note>();

            // Characteristics
            CreateMap<Characteristic, GetCharacteristicDto>();
            CreateMap<CreateCharacteristicDto, Characteristic>();
            CreateMap<UpdatedCharacteristicDto, Characteristic>();

            // BreedingRecordCharacteristics
            CreateMap<BreedingRecordCharacteristic, GetBreedingRecordCharacteristicDto>();
            CreateMap<CreateBreedingRecordCharacteristicDto, BreedingRecordCharacteristic>();
            CreateMap<UpdatedBreedingRecordCharacteristicDto, BreedingRecordCharacteristic>();

        }
    }
}
