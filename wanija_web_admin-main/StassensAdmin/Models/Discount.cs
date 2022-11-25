using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public string PromoCode { get; set; }
        public string Description { get; set; }
        public int IsFlatRate { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountRate { get; set; }
        public double MinOrderAmount { get; set; }
        public double MaxOrderAmount { get; set; }
        public int IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IsOneTime { get; set; }
        public int UsageCount { get; set; }
    }
}
