using System;
using System.ComponentModel.DataAnnotations;

namespace Slate.Models
{
    public class Entity
    {
        [Key]
        public string EntityID { get; set; }
        public int EntityTypeID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        // EF Core currently does not support DateOnly out of the box, so we'll use DateTime
        // and you can ignore the time part when using it.
        public DateTime DOB { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Parameterless constructor for EF
        public Entity() { }
    }
}
