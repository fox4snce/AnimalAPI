using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Character;
using AnimalAPI.Models.Dtos.CharacterSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
        Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}
