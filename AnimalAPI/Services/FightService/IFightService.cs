using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.FightService
{
    public interface IFightService
    {

        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);

        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
    }
}
