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
    
    public partial class TransferMoney
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long DesUserId { get; set; }
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public byte Status { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public string TransferCode { get; set; }
    }
}