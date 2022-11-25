using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class SellerApprovalM
    {
       
        public string ProprietorFirstName { get;  set; } 
        public string ProprietorLastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string StoreAddress { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string CreatePassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Signature { get; set; }
        public string Date { get; set; }
        public string StoreName { get; set; }
        public string LandPhone { get; set; }
        public string StoreLat { get; set; }
        public string StoreLon { get; set; }
        public string StoreLogo { get; set; }
        public string StoreCoverImage { get; set; }

    }
}
