using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public class AppSettings
    {
        public const string sectionName = "paymentDetails";

        public PaymentDetails test { get; set; }
        public PaymentDetails live { get; set; }
    }

    public class PaymentDetails
    {
        public string link { get; set; }
        public string access_key { get; set; }
        public string profile_id { get; set; }
        public string SECRET_KEY { get; set; }
    }
    public class AppSettingsApi
    {
        public const string sectionName = "ApiLinks";

        public string test { get; set; }
        public string live { get; set; }
        public string type { get; set; }
        public string websiteLink { get; set; }
        public string adminPath { get; set; }
        public string clientPath { get; set; }
    }

    public class PaymentGateway
    {
        public const string sectionName = "paymentDetailsLive";

        public string apiPassword { get; set; }
        public string apiUsername { get; set; }
        public string merchant { get; set; }
        public string merchantName { get; set; }
        public string returnUrl { get; set; }
        public string returnUrlMobile { get; set; }
        public string cancelReturnUrl { get; set; }
    }
}
