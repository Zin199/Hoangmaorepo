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
    
    public partial class PartnerServiceConfig
    {
        public int Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public string PartnerCode { get; set; }
        public byte Status { get; set; }
        public string ServiceCode { get; set; }
        public int PartnerId { get; set; }
        public int ServiceId { get; set; }
        public int PaidType { get; set; }
        public Nullable<int> TelcoId { get; set; }
    }
}