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
    
    public partial class AbpBackgroundJob
    {
        public long Id { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<long> CreatorUserId { get; set; }
        public bool IsAbandoned { get; set; }
        public string JobArgs { get; set; }
        public string JobType { get; set; }
        public Nullable<System.DateTime> LastTryTime { get; set; }
        public System.DateTime NextTryTime { get; set; }
        public byte Priority { get; set; }
        public short TryCount { get; set; }
    }
}
