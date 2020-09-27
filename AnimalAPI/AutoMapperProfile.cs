﻿using AnimalAPI.Models;
using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos;
using AnimalAPI.Models.Dtos.BreedingRecords;
using AnimalAPI.Models.Dtos.Character;
using AnimalAPI.Models.Dtos.CharacterSkill;
using AnimalAPI.Models.Dtos.Fight;
using AnimalAPI.Models.Dtos.Weapon;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
            CreateMap<Character, HighScoreDto>();

            CreateMap<BreedingRecord, GetBreedingRecordDto>();
            CreateMap<CreateBreedingRecordDto, BreedingRecord>();
            //.ForMember(dto => dto.Litter, br => br.MapFrom(br => br.BreedingRecordLitters.Select(brl => brl.LitterId)));

            CreateMap<Litter, GetLitterDto>();
        }
    }
}
