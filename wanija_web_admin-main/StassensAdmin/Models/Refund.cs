using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public class Refund
    {
        public string apiOperation { get; set; }
        public Transaction2 transaction { get; set; }
    }
    public class Transaction2
    {
        public double amount { get; set; }
        public string currency { get; set; }
    }

}
