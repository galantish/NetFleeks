using System;
using System.ComponentModel.DataAnnotations;

namespace NetFleeks.Models
{
    public class Purchases
    {
        public int ID { get; set; }
        [Display(Name = "Purchasing User")]
        public User purchaseUser { get; set; }
        [Display(Name = "Purchased Movie")]
        public Movies purchaseMovie { get; set; }
        [Display(Name = "Purchase Expiration Date")]
        public DateTime purchaseExpiration { get; set; }
    }
}
