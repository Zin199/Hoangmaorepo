//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BotTelegram.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChargingTransaction
    {
        public long Id { get; set; }
        public string TransCode { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string CardSerial { get; set; }
        public string CardCode { get; set; }
        public Nullable<byte> CardType { get; set; }
        public Nullable<int> CardAmount { get; set; }
        public Nullable<int> RequestAmount { get; set; }
        public string RequestIpAddress { get; set; }
        public Nullable<short> Status { get; set; }
        public string PartnerCode { get; set; }
        public Nullable<bool> IsCallbackPartner { get; set; }
        public Nullable<bool> IsForceCallback { get; set; }
        public Nullable<System.DateTime> CallbackTime { get; set; }
        public string ProviderCode { get; set; }
        public string ProviderRequestTransCode { get; set; }
        public string ProviderResponseTransCode { get; set; }
        public string ProviderResponseCode { get; set; }
        public string ProviderResponseMessage { get; set; }
        public Nullable<System.DateTime> ProviderCallbackTime { get; set; }
        public Nullable<bool> IsCanRetry { get; set; }
        public int RealCardAmount { get; set; }
        public Nullable<bool> IsFixedProviderCode { get; set; }
        public Nullable<short> InternalErrorCode { get; set; }
        public string InternalErrorMessage { get; set; }
        public Nullable<int> PartnerDiscountPolicyId { get; set; }
        public Nullable<decimal> PartnerDiscountPercentage { get; set; }
        public Nullable<decimal> PartnerCostAmount { get; set; }
        public Nullable<int> ServiceProviderDiscountPolicyId { get; set; }
        public Nullable<decimal> ServiceProviderDiscountPercentage { get; set; }
        public Nullable<decimal> ServiceProviderSaleAmount { get; set; }
        public string ExceptProviderCode { get; set; }
    }
}
