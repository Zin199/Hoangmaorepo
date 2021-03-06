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
    
    public partial class SaleInvoice
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long UserId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal SalePrice { get; set; }
        public int DiscountPolicyId { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal TotalAmount { get; set; }
        public Nullable<decimal> RealTotalAmount { get; set; }
        public byte Status { get; set; }
        public string ReceiveAccount { get; set; }
        public byte Type { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal TotalChargedAmount { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public int MinCardAmount { get; set; }
        public Nullable<byte> PaidType { get; set; }
        public int DecreaseDiscount { get; set; }
        public Nullable<int> Priority { get; set; }
        public string AlowCardAmount { get; set; }
        public string ChannelCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> StartTopupDate { get; set; }
        public Nullable<int> ParentDiscountPolicyId { get; set; }
        public Nullable<long> ParentUserId { get; set; }
        public Nullable<double> ParentDiscountPercentage { get; set; }
        public string Note { get; set; }
        public string SubAccount { get; set; }
        public string SubMobile { get; set; }
        public Nullable<bool> UseFastTopup { get; set; }
        public Nullable<decimal> RefundAmount { get; set; }
        public Nullable<decimal> ParentRefundAmount { get; set; }
        public string Transref { get; set; }
        public Nullable<long> LastChargingTranId { get; set; }
        public Nullable<System.DateTime> ContinueTime { get; set; }
    }
}
