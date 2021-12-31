using AnimalAPI.Models.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.BreedingRecords
{
    public class UpdatedBreedingRecordDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OwnerId { get; set; }
        public bool Public { get; set; } = false;
        public int BirthLitterId { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public int BreederId { get; set; }
        public DateTime DateOfAcquisition { get; set; }


    }
}
