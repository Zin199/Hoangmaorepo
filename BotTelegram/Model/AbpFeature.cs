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
    
    public partial class AbpFeature
    {
        public long Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public string Discriminator { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public Nullable<int> EditionId { get; set; }
        public Nullable<int> TenantId { get; set; }
    
        public virtual AbpEdition AbpEdition { get; set; }
    }
}
