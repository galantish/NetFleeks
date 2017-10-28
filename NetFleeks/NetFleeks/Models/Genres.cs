﻿using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace NetFleeks.Models
{
    public class Genres
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Genre Name")]
        public string genreName { get; set; } 
    }
}
