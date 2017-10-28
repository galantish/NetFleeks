using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetFleeks.Models
{
    public class Movie
    {
        //Change
        [Display(Name = "Movie ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string movieName { get; set; }

        //public Genre genre { get; set; }

        [Display(Name = "Genre ID")]
        [Required]
        public int genreID { get; set; }

        [Display(Name = "Date Added")]
        public DateTime dateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime releaseDate { get; set; }

        [Display(Name = "Actors")]
        [StringLength(150)]
        public string actors { get; set; }

        [Display(Name = "Summary")]
        [StringLength(500)]
        public string summary { get; set; }

    }
}