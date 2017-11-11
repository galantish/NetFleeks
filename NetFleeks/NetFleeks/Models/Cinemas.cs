using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetFleeks.Models
{
    public class Cinemas
    {
        [Required]
        [Display(Name = "Cinema ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Cinema Name")]
        [StringLength(100)]
        public string cinemaName { get; set; }

        [Required]
        [Display(Name = "Cinema Address")]
        public string cinemaAddress { get; set; }
    }

}