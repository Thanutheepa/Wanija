using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class DeliveryFeeLineItem
    {
        public int DeliveryFeeId { get; set; }
        public int DeliveryChargeId { get; set; }
        public string CountryId { get; set; }
        public double WeightFrom { get; set; }
        public double WeightTo { get; set; }
        public double ShippingFee { get; set; }
        public string Description { get; set; }
        public string EstimateDates { get; set; }
        public string StateCode { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
