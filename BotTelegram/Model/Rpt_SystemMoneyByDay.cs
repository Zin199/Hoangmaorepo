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
    
    public partial class Rpt_SystemMoneyByDay
    {
        public int Id { get; set; }
        public System.DateTime ReportDate { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastModifiedTime { get; set; }
        public long SystemAccountId { get; set; }
        public decimal BeforeBalance { get; set; }
        public decimal AfterBalance { get; set; }
        public decimal IncreaseBalance { get; set; }
        public decimal DecreaseBalance { get; set; }
    }
}
