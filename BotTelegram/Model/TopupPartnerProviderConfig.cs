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
    
    public partial class TopupPartnerProviderConfig
    {
        public int Id { get; set; }
        public Nullable<int> FromAmount { get; set; }
        public Nullable<int> ToAmount { get; set; }
        public Nullable<byte> TelcoId { get; set; }
        public string PartnerCode { get; set; }
        public string ProviderCode { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }
}
