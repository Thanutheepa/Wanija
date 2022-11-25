using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string CurrencyType { get; set; }
        public double BuyingRate { get; set; }
        public double SellingRate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CurrencySymbol { get; set; }
    }
}
