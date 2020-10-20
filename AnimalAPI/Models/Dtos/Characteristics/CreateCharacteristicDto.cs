using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.Characteristics
{
    public class CreateCharacteristicDto
    {
        public string Category { get; set; }
        public string Feature { get; set; }
    }
}
