using AnimalAPI.Models.Breeding;
using AnimalAPI.Models.Dtos.Characteristics;
using AnimalAPI.Models.Dtos.Litters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.BreedingRecords
{
    public class GetBreedingRecordDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; } = string.Empty;
        public Contact Owner { get; set; }
        public bool Public { get; set; } = false;
        public Gender Sex { get; set; }
        public DateTime Birthday { get; set; }
        public Contact Breeder { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public List<GetCharacteristicDto> Characteristics { get; set; }
        public GetLitterDto BirthLitter { get; set; }
        public ICollection<Note> Notes { get; set; }


    }
}
