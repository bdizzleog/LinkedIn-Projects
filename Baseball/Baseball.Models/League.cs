using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball.Models
{
    public class League
    {
        [Required]
        [RegularExpression(@"^\d+$")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Leagues cannot contain special characters and must be between 1-40 characters in length")]
        public string Name { get; set; }
    }
}
