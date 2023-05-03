using Entities;
using ServiceContracts.Enums;
using System.ComponentModel.DataAnnotations;


namespace ServiceContracts.DTO
{
    /// <summary>
    /// Acts as DTO for updating Person object
    /// </summary>
    public class PersonUpdateRequest
    {
        [Required(ErrorMessage = "Person ID can't be blank !")]
        public Guid PersonID { get; set; }

        [Required(ErrorMessage = "Person Name can't be blank !")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Email can't be blank !")]
        [EmailAddress(ErrorMessage = "Email value should be a valid email !")]
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GenderOptions? Gender { get; set; }
        public Guid CountryID { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }


        public Person ToPerson()
        {
            return new Person
            {
                PersonID = PersonID,
                PersonName = PersonName,
                Email = Email,
                DateOfBirth = DateOfBirth,
                Gender = Gender.ToString(),
                CountryID = CountryID,
                Address = Address,
                ReceiveNewsLetters = ReceiveNewsLetters
            };
        }
    }
}
