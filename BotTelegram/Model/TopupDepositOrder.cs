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
    
    public partial class TopupDepositOrder
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public Nullable<int> SourceMoneyId { get; set; }
        public Nullable<int> DepositAccountId { get; set; }
        public string RefAccountNo { get; set; }
        public string RefAccountName { get; set; }
        public string RefTransferCode { get; set; }
        public string OrderCode { get; set; }
        public string TransNote { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime CreatedTime { get; set; }
        public System.DateTime LastModifiedTime { get; set; }
        public Nullable<long> TopupOrderId { get; set; }
        public Nullable<System.DateTime> TransactionTime { get; set; }
        public string TransactionId { get; set; }
        public string TransCode { get; set; }
        public string ServiceCode { get; set; }
        public byte[] RowVersion { get; set; }
    }
}