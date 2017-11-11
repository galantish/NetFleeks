using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetFleeks.ViewModel
{
    public class InfoMovieViewModel
    {

        [Display(Name = "Genre Name")]
        public string genre { get; set; }

        [Display(Name = "Movie Name")]
        public string movie { get; set; }
        
        [Required]
        [Display(Name = "Movie ID")]
        public int ID { get; set; }
    
        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Actors")]
        public string actors { get; set; }

        [Display(Name = "Membership Type")]
        public string membershipType { get; set; }

        [Display(Name = "Summary")]
        public string summary { get; set; }

    }
}