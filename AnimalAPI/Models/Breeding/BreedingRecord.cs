using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AnimalAPI.Models.Breeding
{
    public class BreedingRecord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public Contact Owner { get; set; }
        public bool Public { get; set; } = false;
        public DateTime Birthday { get; set; }
        public Gender Sex { get; set; }
        public Contact Breeder { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Litter BirthLitter { get; set; }
        public int BirthLitterId { get; set; }

        public Breed Breed { get; set; }
        public Variety Variety { get; set; }
        public Color Color { get; set; }
        public CoatType CoatType { get; set; }
        public Species Species { get; set; }

        public List<Note> Notes { get; set; }
        public List<MedicalNote> MedicalNotes { get; set; }

    }
}
