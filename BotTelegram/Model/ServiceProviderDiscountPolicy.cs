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
    
    public partial class ServiceProviderDiscountPolicy
    {
        public int Id { get; set; }
        public Nullable<int> ProviderId { get; set; }
        public Nullable<int> ProductCategoryId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public int FromAmount { get; set; }
        public int ToAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public System.DateTime FromTime { get; set; }
        public System.DateTime ToTime { get; set; }
        public byte Status { get; set; }
        public Nullable<int> TenantId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
    }
}
