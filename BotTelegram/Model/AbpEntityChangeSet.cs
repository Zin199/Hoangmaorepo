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
    
    public partial class AbpEntityChangeSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AbpEntityChangeSet()
        {
            this.AbpEntityChanges = new HashSet<AbpEntityChanx>();
        }
    
        public long Id { get; set; }
        public string BrowserInfo { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public string ExtensionData { get; set; }
        public Nullable<int> ImpersonatorTenantId { get; set; }
        public Nullable<long> ImpersonatorUserId { get; set; }
        public string Reason { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<long> UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AbpEntityChanx> AbpEntityChanges { get; set; }
    }
}
