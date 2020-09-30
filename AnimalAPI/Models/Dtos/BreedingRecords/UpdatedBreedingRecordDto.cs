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
        public Contact Owner { get; set; }
        public bool Public { get; set; } = false;

        public int BirthLitterId { get; set; }

        public DateTime Birthday { get; set; }


        public Gender Sex { get; set; }


        public Contact Breeder { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        

    }
}
