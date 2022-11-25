using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using MotherSLAdmin.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public class ApiService : IApiService
    {
        [Inject]
        IConfiguration Configuration { get; set; }
        string testApi = "";
        string liveApi = "";
        string apiType = "";
        private readonly HttpClient httpClient;
        private readonly IOptions<AppSettingsApi> options;
        public ApiService(HttpClient httpClient, IOptions<AppSettingsApi> options)
        {
            this.httpClient = httpClient;
            testApi = options.Value.test;
            liveApi = options.Value.live;
            apiType = options.Value.type;
        }

        //public ApiService()
        //{
           // AppSettingsApi appSettingsApi = Configuration.GetSection("ApiLinks").Get<AppSettingsApi>();
           // testApi = "http://api-wanija.melstasoft.com/";
           // liveApi = "http://api-wanija.melstasoft.com/";
           // apiType = "live";
           // var newHttpClient = new HttpClient();
           // newHttpClient.BaseAddress = new Uri(GetAPI());
           // httpClient = newHttpClient;
        //}
        public HttpClient GetHttpClient()
        {
            return httpClient;
        }

        public string GetAPI()
        {
            if (apiType == "live")
                return liveApi;
            else
                return testApi;
        }

        public async Task<Token> GetToken()
        {
            string postBody = "username=user&password=user&grant_type=password";
            var request = new HttpRequestMessage(new HttpMethod("POST"), GetAPI() + "/token");
            request.Content = new StringContent(postBody);
            using var response = await httpClient.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<Token>();
        }

        public async Task<IEnumerable<Outlet>> GetAllOutlets()
        {
            Token token = (await GetToken());
            using (httpClient)
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), GetAPI() + "/api/v1/Outlet/all"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", token.token_type + " " + token.access_token);

                    var response = await httpClient.SendAsync(request);

                    return await response.Content.ReadFromJsonAsync<Outlet[]>();
                }
            }
        }

        public async Task<IEnumerable<UserType>> GetUserType()
        {
            return await httpClient.GetFromJsonAsync<UserType[]>("api/v1/GetUserTypes");
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await httpClient.GetFromJsonAsync<User[]>("api/v1/GetAllUsers");
        }
       
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/v1/GetAllProductsAdmin");
        }
        public async Task<IEnumerable<Product>> GetAllProductsByOutletId(int outletId)
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/v1/OutletItemByOutletId/"+outletId);
        }
        
        public async Task<ItemImages> GetItemImages(int itemId)
        {
            return await httpClient.GetFromJsonAsync<ItemImages>("api/v1/GetItemImages/"+itemId);
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await httpClient.GetFromJsonAsync<Category[]>("api/v1/Category/null");
        }
        public async Task<string> AddItem(Product newItem)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateCompanyItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> CreateUser(User Newuser)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(Newuser), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateAdminUser/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string>AddSlider(Slider slider)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(slider), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddSlider/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> AddBanner(BannerModel banner)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(banner), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddBanner", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> AddItemImages(ItemImages itemImages)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(itemImages), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddCompanyItemImages/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<IEnumerable<BlogPosts>> GetAllBlogPosts()
        {
            return await httpClient.GetFromJsonAsync<BlogPosts[]>("api/v1/GetAllBlogPosts");
        }
        public async Task<string> AddBlogPosts(BlogPosts blogPost)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(blogPost), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateBlogPost/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateItem(Product newItem)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/UpdateCompanyItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdatePassword(User ResetUser)
        {
            var jsontext = new StringContent(JsonConvert.SerializeObject(ResetUser), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/v1/UpdatePassword/", jsontext);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }
        public async Task<string> UpdateUserName(User Username)
        {
            var jsontext = new StringContent(JsonConvert.SerializeObject(Username), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/v1/UpdateUserName/", jsontext);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddOutletItem(OutletItem newItem)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddOutletItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> UpdateOutletItem(OutletItem newItem)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(newItem), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/UpdateOutletItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<AdminLogin> LoginUser(string email, string password)
        {
            var url = "/api/v1/AdminLoginDetails/" + email + "/" + password;
            var req = await httpClient.GetAsync(url);
            var response = await req.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AdminLogin>(response);
        }

       /* public async Task<Country> GetCountries()
        {
            return await httpClient.GetFromJsonAsync<List<Country>>("/api/v1/country/");
        }*/
        public async Task<IEnumerable<Slider>> GetSlider()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Slider>>("api/v1/Sliders/");
        }

        public async Task<IEnumerable<BannerModel>> GetBanner()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<BannerModel>>("/api/v1/Banners/");
        }

        public async Task<IEnumerable<CurrencyTypes>> GetCurrencyType()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CurrencyTypes>>("/api/v1/GetAllCurrencyTypes/");
        }

        public async Task<IEnumerable<CurrencyRate>> GetAllRates()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CurrencyRate>>("/api/v1/GetAllRates/");
        }

        public async Task<string> AddoutletList(Outlet newOutlet)
        {
            var jsontext = new StringContent(JsonConvert.SerializeObject(newOutlet), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/AddOutlet/", jsontext);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateOutlet(Outlet updateOutlet)
        {
            var jsontext = new StringContent(JsonConvert.SerializeObject(updateOutlet), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/v1/UpdateOutletDetails/", jsontext);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }

        public async Task<IEnumerable<District>> AllDistrict()
        {
            return await httpClient.GetFromJsonAsync<District[]>("/api/v1/District/Null");


        }
        public async Task<string> AddDeliveryFee(DeliveryFeeLineItem deliveryFee)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(deliveryFee), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddDeliveyChargesLineItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddDeliveryCharges(DeliveryCharges deliveryFee)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(deliveryFee), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddDeliveryFee/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddNewCountry(Country country)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(country), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddCountry/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddNewState(State state)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(state), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddState/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddNewDiscount(Discount discount)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(discount), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddDiscount/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> UpdateDiscount(Discount discount)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(discount), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/UpdateDiscount/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> DeleteDiscount(Discount discount)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(discount), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/DeleteDiscount/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> DeletePost(BlogPosts post)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/DeletePost/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> DeleteSlider(Slider slider)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(slider), Encoding.UTF8, "application/json");

            var response = await httpClient.DeleteAsync("/api/v1/DeleteSlider?value="+ slider.CategoryId);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> DeleteBanner(BannerModel banner)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(banner), Encoding.UTF8, "application/json");

            var response = await httpClient.DeleteAsync("/api/v1/DeleteBanner?value=" + banner.Id);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> DeleteUser(User deleteUser)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(deleteUser), Encoding.UTF8, "application/json");

            var response = await httpClient.DeleteAsync("api/v1/DeleteUser?value=" + deleteUser.ID);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
       

        public async Task<List<Discount>> GetDiscounts()
        {
            return await httpClient.GetFromJsonAsync<List<Discount>>("/api/v1/GetAllDiscounts/");
        }
        
        public async Task<List<DeliveryFeeLineItem>> GetAllDeliveryFeeLineItem()
        {
            return await httpClient.GetFromJsonAsync<List<DeliveryFeeLineItem>>("/api/v1/getAllDeliveryFeeLineItems/");
        }
        public async Task<List<DeliveryCharges>> GetAllDeliveryFee()
        {
            return await httpClient.GetFromJsonAsync<List<DeliveryCharges>>("/api/v1/getAllDeliveryFee/");
        }

        public async Task<string> DeleteDeliveryFeeLineItem(DeliveryFeeLineItem item)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/DeleteDeliveryFeeLineItem/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> DeleteDeliveryCharge(DeliveryCharges item)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/DeleteDeliveryCharge/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> AddNewCategory(Category category)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/AddCategory/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> UpdateCategory(Category category)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(category), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v1/UpdateCategory/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> AddGallery(FullGallery fullGallery)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(fullGallery), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/v1/CreateGallery/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<List<Gallery>> GetAllGalleries()
        {
            return await httpClient.GetFromJsonAsync<List<Gallery>>("/api/v1/GetAllGalleries/");
        }
        public async Task<string> DeleteGallery(int id)
        {
            var response = await httpClient.DeleteAsync("/api/v1/DeleteGallery?value="+id);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> AddCurrencyRate(CurrencyRate NewCurrencyRate)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(NewCurrencyRate), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/AddNewRate/", orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateRate(CurrencyRate UpdateCurrencyRate)
        {
            var jsontext = new StringContent(JsonConvert.SerializeObject(UpdateCurrencyRate), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync("/api/v1/UpdateRate/", jsontext);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }

        public async Task<string> DeleteRate(int delterate)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(delterate), Encoding.UTF8, "application/json");

            var response = await httpClient.DeleteAsync("api/v1/DeleteRate?value=" + delterate);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateOrder(Slider slider, int seqValue)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(slider), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v1/UpdateSliderSequence/"+ seqValue, orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<string> UpdateOrderBanner(BannerModel banner, int seqValue)
        {
            var orderDataJson = new StringContent(JsonConvert.SerializeObject(banner), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/v1/UpdateBannerSequence/" + seqValue, orderDataJson);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> UpdateOrderStatus(string orderId, int cancelReasonId, int isRefund)
        {
            var response = await httpClient.PutAsync("/api/v1/UpdateOrderStatusRefund/" + orderId + "/" + cancelReasonId + "/" + isRefund, null);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
        public async Task<IEnumerable<Order>> GetOrderDetails(string orderId)
        {
            Token token = (await GetToken());
            using (httpClient)
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), GetAPI() + "/api/v1/Order/" + orderId))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", token.token_type + " " + token.access_token);

                    var response = await httpClient.SendAsync(request);

                    return await response.Content.ReadFromJsonAsync<Order[]>();
                }
            }
        }

        public async Task<List<CancelReason>> GetCancelReasons()
        {
            return await httpClient.GetFromJsonAsync<List<CancelReason>>("api/v1/GetCancelReasons");
        }

        Task<List<Country>> IApiService.GetCountries()
        {
            //List < Country > countries = new List<Country>();
            //return countries;
            throw new NotImplementedException();
        }

        // public async Task<IEnumerable<Outlet>> GetOutlet()
        //{
        // return await httpClient.GetFromJsonAsync<Outlet[]>("api/v1/GetOutlets");
        //}

        //Seller Approval Part
        public async Task<IEnumerable<SellerApprovalM>> GetSellerApprovals()
        {
            return await httpClient.GetFromJsonAsync<SellerApprovalM[]>("api/v1/GetSellerApprovals");
        }
    }
}
