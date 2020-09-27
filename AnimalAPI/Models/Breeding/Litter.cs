using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Breeding
{
    public class Litter
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public bool Public { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Contact Breeder { get; set; }
        public List<ParentRecord> Parents { get; set; }
        public List<SiblingRecord> Siblings { get; set; }
    }
}
