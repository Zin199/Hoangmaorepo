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
    
    public partial class AppChatMessage
    {
        public long Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public string Message { get; set; }
        public int ReadState { get; set; }
        public int Side { get; set; }
        public Nullable<int> TargetTenantId { get; set; }
        public long TargetUserId { get; set; }
        public Nullable<int> TenantId { get; set; }
        public long UserId { get; set; }
        public Nullable<System.Guid> SharedMessageId { get; set; }
        public int ReceiverReadState { get; set; }
    }
}
