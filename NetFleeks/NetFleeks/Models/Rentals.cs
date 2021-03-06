﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Principal;

namespace NetFleeks.Models
{
    public class Rentals
    {
        public int ID { get; set; }

        [Display(Name = "Renting User")]
        public string rentalUser { get; set; }

        [Display(Name = "Rented Movie")]
        public string rentalMovie { get; set; }

        [Display(Name = "Rental Expiration Date")]
        public DateTime rentalExpiration { get; set; }

    }

}
