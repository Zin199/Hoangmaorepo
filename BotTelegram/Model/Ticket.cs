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
    
    public partial class Ticket
    {
        public long Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<long> LastModifierUserId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public Nullable<int> TransType { get; set; }
        public string TransCode { get; set; }
        public byte Status { get; set; }
        public Nullable<int> TicketTypeId { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
    }
}
