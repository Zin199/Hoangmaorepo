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
    
    public partial class AbpWebhookSendAttempt
    {
        public System.Guid Id { get; set; }
        public System.Guid WebhookEventId { get; set; }
        public System.Guid WebhookSubscriptionId { get; set; }
        public string Response { get; set; }
        public Nullable<int> ResponseStatusCode { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<int> TenantId { get; set; }
    
        public virtual AbpWebhookEvent AbpWebhookEvent { get; set; }
    }
}
