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
    
    public partial class ChargingTransactionCallbackPartnerHistory
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public string TransCode { get; set; }
        public string Status { get; set; }
        public Nullable<byte> CardType { get; set; }
        public string CardSerial { get; set; }
        public string CardCode { get; set; }
        public Nullable<int> CardValue { get; set; }
    }
}
