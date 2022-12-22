using System.Collections;

namespace BeePortal
{
    public class Person
    {


        public int PersonId { get; set; }
        public int PersonNumber { get; set; }
        public string? BeeMail { get; set; } = string.Empty;
        public string? FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public DateTime? DateOfRegistration { get; set; }
        public int? PlaceOfBirth { get; set; } = null;
        public string? CSN { get; set; } = string.Empty;
        public int? AddressId { get; set; } = null;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;




    }
}
