using System;
namespace NetFleeks.Models
{
    public class Purchases
    {
        public int ID { get; set; }
        public User purchaseUser { get; set; }
        public Movies purchaseMovie { get; set; }
        public DateTime purchaseExpiration { get; set; }
    }
}
