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
    
    public partial class AbpUserLoginAttempt
    {
        public long Id { get; set; }
        public string BrowserInfo { get; set; }
        public string ClientIpAddress { get; set; }
        public string ClientName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public byte Result { get; set; }
        public string TenancyName { get; set; }
        public Nullable<int> TenantId { get; set; }
        public Nullable<long> UserId { get; set; }
        public string UserNameOrEmailAddress { get; set; }
    }
}
