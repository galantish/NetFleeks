using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NetFleeks.Models;

namespace NetFleeks.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string fName { get; set; }
        [Required]

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lName { get; set; }

        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        public enum Gender
        {
            Male,
            Female
        }

        [Display(Name = "Membership Type")]
        public MembershipType membershipType { get; set; }

        [Display(Name = "Membership Type ID")]
        public int membershipTypeID { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? birth { get; set; }

        [Display(Name = "Membership Type")]
        public Genres genre { get; set; } 

        [Display(Name = "Favorite Genre ID")]
        public int genreID { get; set; }

    }
}