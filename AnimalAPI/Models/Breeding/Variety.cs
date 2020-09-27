using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Breeding
{
    public class Variety
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
