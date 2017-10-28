using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NetFleeks.Models;
using System.Data.Entity;

namespace NetFleeks.Models
{
    public class Users
    {
        [Required]
        [Display(Name = "User ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string fName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
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

    public class UsersDBContext : DbContext
    {
        public DbSet<Users> users { get; set; }
    }
}