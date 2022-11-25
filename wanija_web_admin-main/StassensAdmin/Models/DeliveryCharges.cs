using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class DeliveryCharges
    {
        public int DeliveryChargeId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public double DeliveryFee { get; set; }
        public int MinOrderValue { get; set; }

        List<DeliveryFeeLineItem> ListDeliveryFeeLineItem { get; set; } = new List<DeliveryFeeLineItem>();
    }
}
