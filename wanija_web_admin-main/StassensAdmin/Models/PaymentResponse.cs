using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class PaymentResponse
    {
        public AuthorizationResponse2 authorizationResponse { get; set; }
        public Customer2 customer { get; set; }
        public Device2 device { get; set; }
        public string gatewayEntryPoint { get; set; }
        public string merchant { get; set; }
        public Order3 order { get; set; }
        public Response2 response { get; set; }
        public string result { get; set; }
        public SourceOfFunds2 sourceOfFunds { get; set; }
        public DateTime timeOfLastUpdate { get; set; }
        public DateTime timeOfRecord { get; set; }
        public Transaction3 transaction { get; set; }
        public string version { get; set; }
        public Error error { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Error
    {
        public string cause { get; set; }
        public string explanation { get; set; }
    }
    public class AuthorizationResponse2
    {
        public string cardLevelIndicator { get; set; }
        public string cardSecurityCodeError { get; set; }
        public string commercialCard { get; set; }
        public string commercialCardIndicator { get; set; }
        public string date { get; set; }
        public string posData { get; set; }
        public string posEntryMode { get; set; }
        public string processingCode { get; set; }
        public string responseCode { get; set; }
        public string returnAci { get; set; }
        public string stan { get; set; }
        public string time { get; set; }
        public string transactionIdentifier { get; set; }
        public string validationCode { get; set; }
        public string vpasResponse { get; set; }
    }

    public class Customer2
    {
        public string firstName { get; set; }
    }

    public class Device2
    {
        public string browser { get; set; }
        public string ipAddress { get; set; }
    }

    public class Chargeback2
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class Order3
    {
        public double amount { get; set; }
        public Chargeback chargeback { get; set; }
        public DateTime creationTime { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public DateTime lastUpdatedTime { get; set; }
        public double merchantAmount { get; set; }
        public string merchantCategoryCode { get; set; }
        public string merchantCurrency { get; set; }
        public string status { get; set; }
        public double totalAuthorizedAmount { get; set; }
        public double totalCapturedAmount { get; set; }
        public double totalDisbursedAmount { get; set; }
        public double totalRefundedAmount { get; set; }
    }

    public class CardSecurityCode2
    {
        public string acquirerCode { get; set; }
        public string gatewayCode { get; set; }
    }

    public class Response2
    {
        public string acquirerCode { get; set; }
        public CardSecurityCode2 cardSecurityCode { get; set; }
        public string gatewayCode { get; set; }
    }

    public class Card2
    {
        public string brand { get; set; }
        public Expiry expiry { get; set; }
        public string fundingMethod { get; set; }
        public string nameOnCard { get; set; }
        public string number { get; set; }
        public string scheme { get; set; }
        public string storedOnFile { get; set; }
    }

    public class Provided2
    {
        public Card2 card { get; set; }
    }

    public class SourceOfFunds2
    {
        public Provided2 provided { get; set; }
        public string type { get; set; }
    }

    public class Acquirer2
    {
        public int batch { get; set; }
        public string date { get; set; }
        public string id { get; set; }
        public string merchantId { get; set; }
        public string settlementDate { get; set; }
        public string timeZone { get; set; }
        public string transactionId { get; set; }
    }

    public class Transaction3
    {
        public Acquirer2 acquirer { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string receipt { get; set; }
        public string source { get; set; }
        public string stan { get; set; }
        public string terminal { get; set; }
        public string type { get; set; }
    }


}
