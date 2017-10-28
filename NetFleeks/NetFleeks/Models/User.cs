﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFleeks.Models
{
    public class User
    {
        [Display(Name = "User ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string fName { get; set; }
        [Required]

        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string lName { get; set; }

        [Display(Name = "Gender")]
        public Gender gender { get; set; }

        public enum Gender
        {
            Male,
            Female
        }

        public MembershipType membershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? birth { get; set; }

        [Display(Name = "Favorite Genre")]
        public int MyProperty { get; set; }

    }
}