using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class Order

    {
        public double OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public double DistrictId { get; set; }
        public double OutletId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public long ContactNumber { get; set; }
        public string CustomerNic { get; set; }
        public double TotalAmount { get; set; }
        public double DeliveryFee { get; set; }
        public double OrderTypeId { get; set; }
        public string Remarks { get; set; }
        public double OrderStatusId { get; set; }
        public double PaymentTypeId { get; set; }
        public DateTime TsrAssignedDate { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double QuarantinePlace { get; set; }
        public double DeliveryModeId { get; set; }
        public string PromotionCode { get; set; }
        public double DiscountAmount { get; set; }
        public double DeliveryOptionId { get; set; }
        public List<ListOrderDetail> ListOrderDetails { get; set; }
        public Outlet2 Outlet { get; set; }
    }
    public class ListOrderDetail
    {
        public double ItemId { get; set; }
        public string ItemName { get; set; }
        public double OrderQuantity { get; set; }
        public double Amount { get; set; }
    }

    public class Outlet2
    {
        public double OutletId { get; set; }
        public string OutletName { get; set; }
        public double CompanyId { get; set; }
        public string OutletAddress { get; set; }
        public double DistrictId { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }
        public double IsActive { get; set; }
        public string ManagerName { get; set; }
        public string LandNumber { get; set; }
        public string ShopId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
