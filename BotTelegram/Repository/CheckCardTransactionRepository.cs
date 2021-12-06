using BotTelegram.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotTelegram.Repository
{
    

    class CheckCardTransactionRepository
    {

        public static Logger _LOG = LogManager.GetCurrentClassLogger();
        public List<CheckCardTransaction> GetCheckCard(string cardSerial)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    //Lay du lieu
                    var CheckCardTrans = db.CheckCardTransactions.Where(c => c.CardSerial == cardSerial).ToList();

                    return CheckCardTrans;
                }
            }
            catch (Exception ex)
            {
                _LOG.Error($"GetCheckCard exeption: {ex.Message}");
            }

            return null;
        }

        public CheckCardTransaction GetCheckCardSerialDung(string cardSerial)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    //Lay du lieu
                    var CheckCardTrans = db.CheckCardTransactions.Where(c => c.CardSerial == cardSerial).FirstOrDefault();

                    return CheckCardTrans;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public CheckCardTransaction GetCheckCardSuccess(int Id)
        {
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                    //Lay du lieu
                    var CheckCardTrans = db.CheckCardTransactions.Where(c => c.Id == Id
                                                                        && c.Status == 1).FirstOrDefault();

                    return CheckCardTrans;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }


        public CheckCardTransaction InsertCheckCard(string serial, byte cardType)
        {
            using (var db = new DevPayExpressEntities())
            {
                var item = new CheckCardTransaction()
                {
                    CardSerial = serial,
                    CardType = cardType,
                    Status = 0,
                    UniqueCardSerial = DateTime.Now.ToString("ddMMyyHHmmssfff"),
                    CreatedTime = DateTime.Now
                };
                try
                {
                    item = db.CheckCardTransactions.Add(item);
                    db.SaveChanges();

                }
                catch(Exception e)
                {
                    Console.WriteLine(e);

                }
              
                return item;
            }
        }
       
    }

    }
