using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using MotherSLAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public interface IPaymentService
    {
        Task<PaymentResponse> RefundPayment(string orderId, double amount);
        Task<PaymentGatewayDetails> GetRefundPaymentDetails(string orderId);
    }
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient httpClient;
        private readonly IOptions<PaymentGateway> options;

        public PaymentService(HttpClient httpClient, IOptions<PaymentGateway> options)
        {
            this.httpClient = httpClient;
            this.options = options;
        }
        public async Task<PaymentResponse> RefundPayment(string orderId, double amount)
        {

            try
            {
                var refundObj = new Refund();
                var transactionObj = new Transaction2();
                refundObj.apiOperation = "REFUND";
                transactionObj.amount = amount;
                transactionObj.currency = "LKR";
                refundObj.transaction = transactionObj;
                var orderDataJson = new StringContent(JsonConvert.SerializeObject(refundObj), Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic bWVyY2hhbnQuQkVMTFZBTlRHTEtSOjBhNjU1OTY0MTI5NjdjMTFmNGQwNzI5ZmQ3MGNiMjFk");
                var response = await httpClient.PutAsync("https://ap-gateway.mastercard.com/api/rest/version/63/merchant/" + options.Value.merchant + "/order/" + orderId + "/transaction/"+orderId, orderDataJson);
                //response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadFromJsonAsync<PaymentResponse>();
                return content;
            }
            catch(Exception e)
            {
                var response = new PaymentResponse();
                var error = new Error();
                error.cause = "Exception";
                error.explanation = e.Message.ToString();
                response.error = error;
                return response;
            }
        }
        
        public async Task<PaymentGatewayDetails> GetRefundPaymentDetails(string orderId)
        {
            /*using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ap-gateway.mastercard.com/api/rest/version/63/merchant/"+ options.Value.merchant + "/order/"+orderId))
                {
                    var contentList = new List<string>();
                    contentList.Add("userid=" + options.Value.apiUsername);
                    contentList.Add("password=" + options.Value.apiPassword);
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }*/
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://ap-gateway.mastercard.com/api/rest/version/63/merchant/" + options.Value.merchant + "/order/" + orderId))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Basic bWVyY2hhbnQuQkVMTFZBTlRHTEtSOjBhNjU1OTY0MTI5NjdjMTFmNGQwNzI5ZmQ3MGNiMjFk");

                    var response = await httpClient.SendAsync(request);
                    var responseBody = await response.Content.ReadFromJsonAsync<PaymentGatewayDetails>();
                    return responseBody;
                }
            }
        }
    }
}
