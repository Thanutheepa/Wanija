using MotherSLAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public interface IApiService
    {
        HttpClient GetHttpClient();
        Task<Token> GetToken();
        Task<IEnumerable<UserType>> GetUserType();
        Task<IEnumerable<User>> GetAllUser();
        Task<IEnumerable<Outlet>> GetAllOutlets();
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsByOutletId(int outletId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Slider>> GetSlider();
        Task<IEnumerable<BannerModel>> GetBanner();
        Task<IEnumerable<CurrencyTypes>> GetCurrencyType();
        Task<IEnumerable<CurrencyRate>> GetAllRates();
       
        Task<string> AddoutletList(Outlet newOutlet);
        Task<string> UpdateOutlet(Outlet updateOutlet);
        Task<IEnumerable<District>> AllDistrict();
      
        Task<string> CreateUser(User Newuser);
        Task<string> AddItem(Product newItem);
        Task<string> AddSlider(Slider slider);
        Task<string> AddBanner(BannerModel banner);
        Task<string> UpdateItem(Product newItem);
        Task<string> UpdateUserName(User Username);

        Task<string> UpdatePassword(User ResetUser);
        Task<string> AddOutletItem(OutletItem newItem);
        Task<string> UpdateOutletItem(OutletItem newItem);
        Task<AdminLogin> LoginUser(string email, string password);
        Task<ItemImages> GetItemImages(int itemId);
        Task<string> AddItemImages(ItemImages itemImages);
        Task<string> AddBlogPosts(BlogPosts blogPost);
        Task<List<Country>> GetCountries();
        Task<string> AddDeliveryFee(DeliveryFeeLineItem deliveryFee);
        Task<string> AddNewCountry(Country country);
        Task<string> AddNewState(State state);
        Task<string> AddNewDiscount(Discount discount);
        Task<List<Discount>> GetDiscounts();
        Task<string> UpdateDiscount(Discount discount);
        Task<string> DeleteDiscount(Discount discount);
        Task<string> DeletePost(BlogPosts post);
        Task<string> DeleteSlider(Slider slider);
        Task<string> DeleteBanner(BannerModel banner);
        Task<string> DeleteUser(User deleteUser);
        Task<string> AddDeliveryCharges(DeliveryCharges deliveryFee);
        Task<IEnumerable<BlogPosts>> GetAllBlogPosts();
        Task<List<DeliveryCharges>> GetAllDeliveryFee();
        Task<List<DeliveryFeeLineItem>> GetAllDeliveryFeeLineItem();
        Task<string> DeleteDeliveryFeeLineItem(DeliveryFeeLineItem item);
        Task<string> DeleteDeliveryCharge(DeliveryCharges item);
        Task<string> AddNewCategory(Category category);
        Task<string> UpdateCategory(Category category);
        Task<string> AddGallery(FullGallery fullGallery);
        Task<List<Gallery>> GetAllGalleries();
        Task<string> DeleteGallery(int id);

        Task<string> AddCurrencyRate(CurrencyRate NewCurrencyRate);
        Task<string> UpdateRate(CurrencyRate UpdateCurrencyRate);
        Task<string> DeleteRate(int delterate);
        Task<string> UpdateOrder(Slider slider, int seqValue);
        Task<string> UpdateOrderBanner(BannerModel banner, int seqValue);
        Task<string> UpdateOrderStatus(string orderId, int cancelReasonId, int isRefund);
        Task<IEnumerable<Order>> GetOrderDetails(string orderId);
        Task<List<CancelReason>> GetCancelReasons();
        Task<IEnumerable<SellerApprovalM>> GetSellerApprovals();

    }
}
