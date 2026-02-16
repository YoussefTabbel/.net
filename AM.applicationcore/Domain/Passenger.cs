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
        [MinLength = 3, ErrorMessage = "First name must be at least 3 characters long.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        [Key]
        [StringLength(7, ErrorMessage = "Passport number must be exactly 8 characters.")]
        public string PassportNumber { get; set; }
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
