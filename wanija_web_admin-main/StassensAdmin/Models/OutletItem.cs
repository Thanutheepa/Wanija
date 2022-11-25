using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class OutletItem
    {
        public int OutletId { get; set; }

        public int ItemId { get; set; }

        public double CurrentStock { get; set; }

        public double UnitPrice { get; set; }
    }
}
