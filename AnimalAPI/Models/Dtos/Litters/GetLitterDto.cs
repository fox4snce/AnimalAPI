using AnimalAPI.Models.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.Litters
{
    public class GetLitterDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Contact Breeder { get; set; }

        public List<ParentRecord> Parents { get; set; }
        public List<SiblingRecord> Siblings { get; set; }

    }
}
