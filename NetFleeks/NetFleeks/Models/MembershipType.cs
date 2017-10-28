using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetFleeks.Models
{
    public class MembershipType
    {
        [Required]
        [Display(Name = "Membership Type ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        [StringLength(100)]
        public string membershipType { get; set; }

        [Display(Name = "Duration")]
        [StringLength(100)]
        public int duration { get; set; }

        [Display(Name = "Payment")]
        [StringLength(100)]
        public int payment { get; set; }
    }
}