using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball.Models
{
    public class Team
    {
        [Required]
        [RegularExpression(@"^\d+$")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Team names contain special characters and has to be between 1 and 40 characters in length")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Manager names contain special characters and has to be between 1 and 40 characters in length")]
        public string Manager { get; set; }

        [RegularExpression(@"^\d+$")]
        public int LeagueId { get; set; }

        public List<Player> Players { get; set; }    
    }
}