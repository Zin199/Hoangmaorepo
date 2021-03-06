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
    
    public partial class PinCodeStock
    {
        public long Id { get; set; }
        public Nullable<byte> CardType { get; set; }
        public string CardSerial { get; set; }
        public string CardCode { get; set; }
        public Nullable<int> CardAmount { get; set; }
        public Nullable<System.DateTime> ExpiredTime { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ExportedTime { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<bool> IsEncrypted { get; set; }
        public string TransRef { get; set; }
        public string ImportRef { get; set; }
        public string ImportProvider { get; set; }
        public string Info { get; set; }
        public string UserUpdate { get; set; }
        public Nullable<long> InvoiceId { get; set; }
        public Nullable<double> ImportDiscount { get; set; }
        public Nullable<double> ExportDiscount { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
