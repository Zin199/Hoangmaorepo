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
    
    public partial class AppFriendship
    {
        public long Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.Guid> FriendProfilePictureId { get; set; }
        public string FriendTenancyName { get; set; }
        public Nullable<int> FriendTenantId { get; set; }
        public long FriendUserId { get; set; }
        public string FriendUserName { get; set; }
        public int State { get; set; }
        public Nullable<int> TenantId { get; set; }
        public long UserId { get; set; }
    }
}
