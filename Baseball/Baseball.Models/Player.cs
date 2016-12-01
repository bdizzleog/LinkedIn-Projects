using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Baseball.Models
{
    public class Player
    {
        //[Required]
        [RegularExpression(@"^\d+$")]
        public int Id { get; set; }
      
        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Cannot contain special characters and has to be between 1 and 40 characters in length")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Cannot contain special characters and has to be between 1 and 40 characters in length")]
        public string LastName { get; set; }


        [Required]
        [RegularExpression(@"^[\d+]{1,2}$", ErrorMessage = "Numbers only max length 2")]
        public int? JerseyNumber { get; set; }

        [Required]
        //probably needs some other sort of validation maybe positive integers?
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,20}$")]
        public Positions? Position { get; set; }

        //[RegularExpression(@"^\d+$", ErrorMessage = "Batting Average error message goes here")]
        //TODO: Alex, fix validation
        public double? BattingAvg { get; set; }

        [Required]
        [RegularExpression(@"^[\d+]{1,2}", ErrorMessage = "Years can only be between 0 and 99")]
        public int? YearsPlayed { get; set; }

        [Required]
        [RegularExpression(@"^\d+$")]
        public int TeamId { get; set; }    
    }
}