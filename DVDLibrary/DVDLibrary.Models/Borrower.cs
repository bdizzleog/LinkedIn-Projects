using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class Borrower
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "First Name cannot contain special characters.")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Last Name cannot contain special characters.")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^(\+[0-9]{9})$", ErrorMessage = "Not a valid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
