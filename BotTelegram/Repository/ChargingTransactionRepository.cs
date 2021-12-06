using BotTelegram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegram.Repository
{
    public class ChargingTransactionRepository
    {
        public ChargingTransaction GetTransactionBySerialPartnerCode(string cardSerial, List<string> listPartnerCode)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    //Lay du lieu
                    var chargingTranList = db.ChargingTransactions.Where(c => c.CardSerial == cardSerial && listPartnerCode.Contains(c.PartnerCode)).ToList();

                    var chargingTran = chargingTranList.FirstOrDefault(c => c.Status == Constant.CARD_STATUS_SUCCESS);
                    if (chargingTran != null)
                    {
                        chargingTran.IsCallbackPartner = false;

                        db.SaveChanges();
                        return chargingTran;
                    }                                     
                    chargingTran = chargingTranList.FirstOrDefault(c => c.Status == Constant.CARD_STATUS_FAILED && c.RealCardAmount > 0);
                    if (chargingTran != null)
                    {
                        chargingTran.IsCallbackPartner = false;

                        db.SaveChanges();
                        return chargingTran;
                    }
                    chargingTran = chargingTranList.Where(c => c.Status == Constant.CARD_STATUS_FAILED && c.InternalErrorMessage != "Invalid card code format").OrderBy(c => c.Id).FirstOrDefault();
                    if (chargingTran != null)
                    {
                        chargingTran.IsCallbackPartner = false;

                        db.SaveChanges();
                        return chargingTran;
                    }
                    chargingTran = chargingTranList.Where(c => c.Status == Constant.CARD_STATUS_FAILED).OrderBy(c => c.Id).FirstOrDefault();
                    if (chargingTran != null)
                    {
                        chargingTran.IsCallbackPartner = false;

                        db.SaveChanges();
                        return chargingTran;
                    }
                    chargingTran = chargingTranList.FirstOrDefault(c => c.Status == Constant.CARD_STATUS_NOT_USE);
                    if (chargingTran != null)
                    {
                        chargingTran.IsCallbackPartner = false;

                        db.SaveChanges();
                        return chargingTran;
                    }




                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }
        public ChargingTransaction GetTransactionBySerialFalsePartnerCode(string cardSerial, List<string> listPartnerCode)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {                 
                    var chargingTran = db.ChargingTransactions.Where(c =>  c.CardSerial == cardSerial && c.InternalErrorCode == 6 
                                                                        && listPartnerCode.Contains(c.PartnerCode)                                                                      
                                                                        ).FirstOrDefault();                   
                    

                    return chargingTran;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public ChargingTransaction UpdateSerialFalse(ChargingTransaction chargingTran, int status, int cardamount)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    var item = db.ChargingTransactions.FirstOrDefault(c => c.Id ==  chargingTran.Id);
                    if (item != null)
                    {
                        
                        item.Status = (short)status;
                        item.CardAmount = cardamount;
                        item.IsCallbackPartner = false;

                        db.SaveChanges();
                        return item;
                    }
                }
            }

            catch (Exception ex)
            {

            }
            return null;
        }
        public ChargingTransaction UpdateSerialWrong( ChargingTransaction chargingTran, int Status, int CardAmount)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    var item = db.ChargingTransactions.FirstOrDefault(c => c.Id == chargingTran.Id);

                    if (item != null)
                    {
                        item.Status = (short)Status;
                        item.CardAmount = CardAmount;
                        item.IsCallbackPartner = false;

                        db.SaveChanges();
                        return item;
                    }
                }
            }
            catch (Exception)
            {

            }
            return null;
        }


    }
}
