using System;
using System.Collections.Generic;
using System.Text;

namespace MotherSLAdmin.Models
{
    public class Outlet
    {
        public int OutletId { get; set; }
        public string OutletName { get; set; }
        public int CompanyId { get; set; }
        public string OutletAddress { get; set; }
        public int DistrictId { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public int IsActive { get; set; }
        public string ManagerName { get; set; }
        public string LandNumber { get; set; }
        public string ShopId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public District _district { get; set; }
    }

    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public List<ListDistrictLeader> ListDistrictLeader { get; set; }
    }

    public class ListDistrictLeader
    {
        public int DistrictLeaderId { get; set; }
        public string DistrictLeaderName { get; set; }
        public int DistrictCode { get; set; }
        public int ContactNo { get; set; }
        public District _district { get; set; }
    }

}
