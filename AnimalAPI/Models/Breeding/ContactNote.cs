using AnimalAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Breeding
{
    public class ContactNote
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Edited { get; set; } = DateTime.Now;
        public bool Medical { get; set; } = false;
        public string Title { get; set; }
        public string Body { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

    }
}
