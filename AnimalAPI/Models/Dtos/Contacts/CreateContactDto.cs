using AnimalAPI.Models.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Models.Dtos.Contacts
{
    public class CreateContactDto
    {
        public int Id { get; set; }
        public bool Public { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ContactType Type { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public List<Note> Notes { get; set; }

    }
}
