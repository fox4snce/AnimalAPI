using AnimalAPI.Models;
using AnimalAPI.Models.Dtos.Character;
using AnimalAPI.Models.Dtos.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}
