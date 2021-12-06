﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotTelegram.Model;
using NLog;

namespace BotTelegram.Repository
{
    
    public class PartnerRepository
    {
        public static Logger _LOG = LogManager.GetCurrentClassLogger();
        public Partner GetPartnerByTelegramGroupId(string telgramGroupId)
        {

            try
            {
                using (var db = new DevPayExpressEntities()) 
                {
                    var parnter = db.Partners.Where(s => s.TelegramSuportGroupId == telgramGroupId).FirstOrDefault();

                    return parnter;
                }
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public List<string> GetListPartnerByTelegramGroupId(string telgramGroupId)
        {


            var parnter = new List<string>();
            try
            {
                using (var db = new DevPayExpressEntities())
                {
                     parnter = db.Partners.Where(s => s.TelegramSuportGroupId == telgramGroupId).Select(s => s.Code).ToList();

                    return parnter;
                }
            }
            catch (Exception ex)
            {
                _LOG.Error($"GetListPartnerByTelegramGroupId exeption: {ex.Message}");
            }
            return parnter;
        }

    }
}
