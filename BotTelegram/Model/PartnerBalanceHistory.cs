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
    
    public partial class PartnerBalanceHistory
    {
        public long Id { get; set; }
        public long PartnerId { get; set; }
        public decimal Balance { get; set; }
        public string InvoiceCode { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<byte> BalanceType { get; set; }
        public Nullable<byte> InvoiceType { get; set; }
    }
}
