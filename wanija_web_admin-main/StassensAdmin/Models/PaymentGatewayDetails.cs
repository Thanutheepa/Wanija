﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class PaymentGatewayDetails
    {
        public _3DSecure _3DSecure { get; set; }
        public string _3DSecureId { get; set; }
        public double amount { get; set; }
        public Chargeback chargeback { get; set; }
        public DateTime creationTime { get; set; }
        public string currency { get; set; }
        public Customer customer { get; set; }
        public string description { get; set; }
        public Device device { get; set; }
        public string id { get; set; }
        public DateTime lastUpdatedTime { get; set; }
        public string merchant { get; set; }
        public double merchantAmount { get; set; }
        public string merchantCategoryCode { get; set; }
        public string merchantCurrency { get; set; }
        public string result { get; set; }
        public SourceOfFunds sourceOfFunds { get; set; }
        public string status { get; set; }
        public double totalAuthorizedAmount { get; set; }
        public double totalCapturedAmount { get; set; }
        public double totalDisbursedAmount { get; set; }
        public double totalRefundedAmount { get; set; }
        public List<Transaction> transaction { get; set; }
    }
    public class _3DSecure
    {
        public string acsEci { get; set; }
        public string authenticationToken { get; set; }
        public string paResStatus { get; set; }
        public string veResEnrolled { get; set; }
        public string xid { get; set; }
    }

    public class Chargeback
    {
        public int amount { get; set; }
        public string currency { get; set; }
    }

    public class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Device
    {
        public string browser { get; set; }
        public string ipAddress { get; set; }
    }

    public class Expiry
    {
        public string month { get; set; }
        public string year { get; set; }
    }

    public class Card
    {
        public string brand { get; set; }
        public Expiry expiry { get; set; }
        public string fundingMethod { get; set; }
        public string nameOnCard { get; set; }
        public string number { get; set; }
        public string scheme { get; set; }
        public string storedOnFile { get; set; }
    }

    public class Provided
    {
        public Card card { get; set; }
    }

    public class SourceOfFunds
    {
        public Provided provided { get; set; }
        public string type { get; set; }
    }

    public class AuthorizationResponse
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

    public class Order2
    {
        public double amount { get; set; }
        public Chargeback chargeback { get; set; }
        public DateTime creationTime { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
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

    public class CardSecurityCode
    {
        public string acquirerCode { get; set; }
        public string gatewayCode { get; set; }
    }

    public class Response
    {
        public string acquirerCode { get; set; }
        public string acquirerMessage { get; set; }
        public CardSecurityCode cardSecurityCode { get; set; }
        public string gatewayCode { get; set; }
    }

    public class Acquirer
    {
        public int batch { get; set; }
        public string date { get; set; }
        public string id { get; set; }
        public string merchantId { get; set; }
        public string settlementDate { get; set; }
        public string timeZone { get; set; }
        public string transactionId { get; set; }
    }

    public class Transaction
    {
        public Acquirer acquirer { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public string id { get; set; }
        public string receipt { get; set; }
        public string source { get; set; }
        public string stan { get; set; }
        public string terminal { get; set; }
        public string type { get; set; }
        public string authorizationCode { get; set; }
        public _3DSecure _3DSecure { get; set; }
        public string _3DSecureId { get; set; }
        public AuthorizationResponse authorizationResponse { get; set; }
        public Customer customer { get; set; }
        public Device device { get; set; }
        public string gatewayEntryPoint { get; set; }
        public string merchant { get; set; }
        public Order2 order { get; set; }
        public Response response { get; set; }
        public string result { get; set; }
        public SourceOfFunds sourceOfFunds { get; set; }
        public DateTime timeOfLastUpdate { get; set; }
        public DateTime timeOfRecord { get; set; }
        public Transaction transaction { get; set; }
        public string version { get; set; }
        public Initiator initiator { get; set; }
    }

    public class Initiator
    {
        public string userId { get; set; }
    }
}
