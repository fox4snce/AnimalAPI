using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Breeding
{
    public class ParentRecord
    {
        public int ParentId { get; set; }
        public BreedingRecord Parent { get; set; }
        public int LitterId { get; set; }
        public Litter Litter { get; set; }
    }
}
