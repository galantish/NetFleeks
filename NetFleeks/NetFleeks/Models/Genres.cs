using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace NetFleeks.Models
{
    public class Genres
    {
        public int ID { get; set; }

        [Display(Name = "Genre Name")]
        public genreEnum genreName { get; set; }

        public enum genreEnum 
        { 
            Comedy, 
            RomanticComedy, 
            Drama, 
            Action, 
            Horror, 
            Kids, 
            Adult 
        } 
    }
}
