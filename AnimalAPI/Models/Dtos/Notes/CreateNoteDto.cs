using AnimalAPI.Models.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.Notes
{
    public class CreateNoteDto
    {

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; } = DateTime.Now;
        public bool Medical { get; set; } = false;
        public string Title { get; set; }
        public string Body { get; set; }
        public int? BreedingRecordId { get; set; } = null;
        public int? ContactId { get; set; } = null;

        
    }
}
