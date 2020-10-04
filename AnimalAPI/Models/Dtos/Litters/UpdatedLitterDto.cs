﻿using AnimalAPI.Models.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.Litters
{
    public class UpdatedLitterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Public { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Contact Breeder { get; set; }
        
    }
}
