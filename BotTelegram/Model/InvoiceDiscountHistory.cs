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
    
    public partial class InvoiceDiscountHistory
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long InvoiceId { get; set; }
        public int Discount { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}