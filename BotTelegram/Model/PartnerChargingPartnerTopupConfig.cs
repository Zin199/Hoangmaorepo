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
    
    public partial class PartnerChargingPartnerTopupConfig
    {
        public int Id { get; set; }
        public string ChargingPartnerCode { get; set; }
        public string TopupPartnerCode { get; set; }
        public Nullable<byte> CardType { get; set; }
        public Nullable<int> FromCardAmount { get; set; }
        public Nullable<int> ToCardAmount { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
    }
}
