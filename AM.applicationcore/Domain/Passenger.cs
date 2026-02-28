using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        [MinLength ( 3, ErrorMessage = "First name must be at least 3 characters long.")]
        [MaxLength(25, ErrorMessage = "First name cannot exceed 25 characters.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string EmailAddress { get; set; }
        [Key]
        [StringLength(7, ErrorMessage = "Passport number must be exactly 8 characters.")]
        public string PassportNumber { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "Telephone number must be exactly 8 digits.")]
        public int TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return $"Passenger: {FirstName} {LastName}, Passport: {PassportNumber}";
        }
        public  bool CheckProfile(string firstName, string lastName)
        {
            return FirstName == firstName && LastName == lastName;
        }
        public bool CheckProfile(string firstName, string lastName, string email)
        {
            return FirstName == firstName && LastName == lastName && EmailAddress == email;
        }
        public bool login(string firstName, string lastName, string email = null)
        {
            if (email == null)
            {
                return CheckProfile(firstName, lastName);
            }
            else
            {
                return CheckProfile(firstName, lastName, email);
            }
        }

    }
    
}
