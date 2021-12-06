﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotTelegram.Model;
namespace BotTelegram.Repository
{
    class PinCodeStockRepository
    {      
      public PinCodeStock GetPinCode(string cardSerial)
        {
            try
            {
                using (var db = new DevPayExpressEntities()) 
                {
                    var pincode = db.PinCodeStocks.Where(c => c.CardSerial == cardSerial).FirstOrDefault();
                    return pincode;
                }              
            }
            catch(Exception ex)
            {

            }
            return null;
        }
        
      public PinCodeStock UpdatePinCode(string cardSerial)
        {
            try
            {
               




            }
            catch (Exception)
            {

            }
            return null;
        }
        
    }
}
