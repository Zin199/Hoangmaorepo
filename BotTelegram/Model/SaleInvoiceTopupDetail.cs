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
    
    public partial class SaleInvoiceTopupDetail
    {
        public long Id { get; set; }
        public long SaleInvoiceId { get; set; }
        public byte TelcoId { get; set; }
        public int Amount { get; set; }
        public string Mobile { get; set; }
        public short PaidType { get; set; }
        public string Transcode { get; set; }
        public string PartnerCode { get; set; }
        public string Transref { get; set; }
        public byte Status { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public Nullable<System.DateTime> StartProcessTime { get; set; }
        public Nullable<System.DateTime> EndProcessTime { get; set; }
        public string RequestInfo { get; set; }
        public string ResponseInfo { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<int> RefundAmount { get; set; }
        public Nullable<long> RefundTransactionId { get; set; }
        public Nullable<bool> IsRefund { get; set; }
        public Nullable<double> ProviderDiscount { get; set; }
    }
}
