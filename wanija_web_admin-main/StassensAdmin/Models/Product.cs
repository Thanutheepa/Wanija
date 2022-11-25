using System;
using System.Collections.Generic;
using System.Text;

namespace MotherSLAdmin.Models
{
    public class Product
    {
        //public int ProductId { get; set; }
        //public string Name { get; set; }
        //public int Qty { get; set; }
        //public double Price { get; set; }
        //public string Image { get; set; }
        //public string Description { get; set; }

        public int productId { get; set; }
        public string name { get; set; }
        public int CompanyId { get; set; }
        public string ItemCode { get; set; }
        public double Cost { get; set; }
        public double SellingPrice { get; set; }
        public double RegularPrice { get; set; }
        public int UOMId { get; set; }
        public int IsActive { get; set; }
        public int MaxQtyPurchase { get; set; }
        public int IsOnline { get; set; }
        public int ProductCategoryId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int IsSathosa { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public int DisplayOrder { get; set; }
        public double CurrentStock { get; set; }
    }
}
