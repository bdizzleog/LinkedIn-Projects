using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace DVDLibrary.Models
{
    public class DVD
    {
        [RegularExpression(@"^\d+$")]
        public int Id { get; set; }

        //stuff we get from OMDB
        [Required]
        [DisplayName("Movie Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Year")]
        public string Year { get; set; }

        [Required]
        [DisplayName("MPAA Rating")]
        [ScriptIgnore]
        public MPAARating Rating { get; set; }
        public string RatingString { get { return Rating.ToString(); } }

        [DisplayName("Day Released")]
        public DateTime Released { get; set; }

        [DisplayName("Run Time")]
        public string RunTime { get; set; }

        [DisplayName("Genre")]
        public string Genre { get; set; }

        [DisplayName("Director")]
        public string Director { get; set; }

        [DisplayName("Writer")]
        public string Writer { get; set; }

        [DisplayName("Actors")]
        public string Actors { get; set; }

        [DisplayName("Plot Synopsis")]
        public string Plot { get; set; }

        [DisplayName("Languge")]
        public string Language { get; set; }

        [DisplayName("Awards")]
        public string Awards { get; set; }

        [DisplayName("Poster Link")]
        public string Poster { get; set; }

        [DisplayName("MetaScore")]
        public int Metascore { get; set; }

        [DisplayName("IMDB Rating")]
        public decimal ImdbRating { get; set; }

        [DisplayName("ImdbID")]
        public string ImdbId { get; set; }

        //stuff that users always have to input themselves

        [DisplayName("Studio")]
        public string Studio { get; set; }

        [DisplayName("User Rating")]
        public decimal UserRating { get; set; }

        [DisplayName("Notes")]
        public string UserNotes { get; set; }
        
        //stuff for lending movies
        [ScriptIgnore]
        public LendingStatus Status { get; set; }
        public string StatusString { get { return Status.ToString(); } }

        public DateTime? CheckOutDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        //[ScriptIgnore]
        public Borrower Borrower { get; set; }
        //public string BorrowerName {
        //    get
        //    {
        //        return
        //            Borrower.FirstName + " " + Borrower.LastName;
        //    }
        //} 
    }
    }

