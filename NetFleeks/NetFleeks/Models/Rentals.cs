using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace NetFleeks.Models
{
    public class Rentals
    {
        public int ID { get; set; }

        [Display(Name = "Renting User")]
        public ApplicationUser rentalUser { get; set; }

        [Display(Name = "Rented Movie")]
        public Movies rentalMovie { get; set; }

        [Display(Name = "Rental Expiration Date")]
        public DateTime rentalExpiration { get; set; }
    }

}
