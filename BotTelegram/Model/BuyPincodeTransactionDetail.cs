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
    
    public partial class BuyPincodeTransactionDetail
    {
        public long Id { get; set; }
        public long BuyPincodeTransactionId { get; set; }
        public Nullable<byte> CardType { get; set; }
        public string CardSerial { get; set; }
        public string CardCode { get; set; }
        public Nullable<int> CardAmount { get; set; }
        public Nullable<System.DateTime> ExpiredTime { get; set; }
        public Nullable<System.DateTime> ExportedTime { get; set; }
        public Nullable<bool> IsEncrypted { get; set; }
        public string TrippdesKey { get; set; }
        public Nullable<long> PinCodeStockId { get; set; }
    }
}
