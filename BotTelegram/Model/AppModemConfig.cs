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
    
    public partial class AppModemConfig
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIp { get; set; }
        public string DeviceUserName { get; set; }
        public string DevicePassword { get; set; }
        public string Port { get; set; }
        public string PortStatus { get; set; }
        public string SimNo { get; set; }
        public Nullable<System.DateTime> LastChargedTime { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public string AppName { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}
