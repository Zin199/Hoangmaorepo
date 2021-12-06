﻿using BotTelegram.Repository;
using System;
using System.Linq;
using System.Threading;
using Telegram.Bot.Args;
using Telegram.Bot;
using System.Collections.Generic;
using BotTelegram.Model;
using NLog;
using ServiceStack;
using BotTelegram.Service;

namespace BotTelegram
{
    class Program
    {

        public static Logger _LOG = LogManager.GetCurrentClassLogger();

        //Bot test
        private static TelegramBotClient bot = new TelegramBotClient("1623962486:AAEnaEoZjtJ7cG8YSFTF4bHh6le2Oa4mXA4");

        //Bot Release
        //private static TelegramBotClient bot = new TelegramBotClient("1015933066:AAGT6BBzsN5a-TfV606Z7X0yAYlbWTdhJJg");


        private static ChargingTransactionRepository _chargingTransactionRepository = new ChargingTransactionRepository();

        private static CheckCardTransactionRepository _checkCardTransactionRepository = new CheckCardTransactionRepository();

        private static TopupTransactionRepository _topupTransactionRepository = new TopupTransactionRepository();

        private static ChargingTopupTransactionRepository _chargingTopupTransactionRepository = new ChargingTopupTransactionRepository();

        private static ServiceProviderRepository _serviceProviderRepository = new ServiceProviderRepository();

        private static PartnerRepository _partnerRepository = new PartnerRepository();

        private static PincodeService _pincodeService = new PincodeService();


        //public static string INTERNAL_TELEGRAM_GROUPID = "-1";


        //private static System.Timers.Timer _checkCardTimer = new System.Timers.Timer();


        private static void Main(string[] args)
        {
            bot.OnMessage += ChargingTrans;

            //TopupTrans();
            bot.StartReceiving();
            Console.WriteLine("Start receiving");
            Console.ReadLine();



        }

        private static void ChargingTrans(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            try
            {
                Console.WriteLine("Tim the");
                _LOG.Info(e.Message.ToJson());
                CheckSerial(e);
                CheckSaiDung(e);

            }
            catch (Exception ex)
            {
                _LOG.Error($"Exception: {ex.Message}");
            }
        }
        private static void CheckSerial(Telegram.Bot.Args.MessageEventArgs e)
        {

          

                var listPartnerCode = _partnerRepository.GetListPartnerByTelegramGroupId(e.Message.Chat.Id.ToString());
               //var providerCode = _serviceProviderRepository.GetChargingTelegramSupportID(e.Message.Chat.Id.ToString());
            _LOG.Info($"List partner: {listPartnerCode.ToJson()}");
            if (listPartnerCode.Count > 0 && e.Message.Text.StartsWith("/sr"))
                {
                    Console.WriteLine("Lay dc serial");
                    var serial = e.Message.Text.Replace("/sr", "").Trim();

                    var chargingTran = _chargingTransactionRepository.GetTransactionBySerialPartnerCode(serial, listPartnerCode);

                    //bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial {chargingTran.CardSerial}.\nA/c đợi 1 chút bên em kiểm tra và trả lời kết quả ạ. ");



                    if (chargingTran != null)
                    {
                        _LOG.Info($"GetChargingTran: {chargingTran.ToJson()}");

                        if (chargingTran.Status == Constant.CARD_STATUS_SUCCESS)
                        {
                            //TH tc chua nhan dc callback

                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được thẻ serial: {serial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nTrạng thái: {Constant.CARDSTATUS[(byte)chargingTran.Status]}\nMệnh giá gửi: {chargingTran.RequestAmount}\nMệnh giá thực: {chargingTran.RealCardAmount}.\nĐã thực hiện callback lại lần nữa, A/c kiểm tra lại giúp.");

                        }
                        else if (chargingTran.Status == 2 && chargingTran.InternalErrorCode == 6)
                        {   //TH sai serial
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nTrạng thái: SAI SERI\nMệnh giá gửi: {chargingTran.RequestAmount}.\nGửi giúp em thông tin serial đúng theo cú pháp: \"/sai serialsai /dung serialdung\"\nVí dụ: \"/sai 1000123123 /dung 10001231234\"");
                        }
                        else if (chargingTran.Status == 2 && chargingTran.RealCardAmount > 0)
                        {
                            //update menh gia thuc khi len sai menh gia
                            var update = _chargingTransactionRepository.UpdateSerialWrong(chargingTran, 1, chargingTran.RealCardAmount);
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}\nMệnh giá thực: {chargingTran.RealCardAmount}.\nĐã thực hiện callback, a/c kiểm tra lại giúp.");
                        }
                        else if (chargingTran.Status == 100)
                        {
                            //TH the k su dung
                            Console.WriteLine("the k sd");
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận đc serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nTrạng thái: THẺ KHÔNG SỬ DỤNG\nMệnh giá gửi: {chargingTran.RequestAmount}.\nĐã thực hiện callback lại lần nữa, a/c kiểm tra lại giúp.");
                        }
                        else if (chargingTran.Status == 2 & chargingTran.InternalErrorMessage == "Invalid card code format")
                        {
                            //TH the k dung dinh dang
                            Console.WriteLine("k dung dinh dang");
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận đc serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nTrạng thái: THẺ SAI ĐỊNH DẠNG\nMệnh giá gửi: {chargingTran.RequestAmount}.\nA/c kiểm tra lại giúp.");
                        }
                        else if (chargingTran.ProviderCode != "PAYEXPRESS" && chargingTran.ProviderCode != "THANHTOANVIP")
                        {


                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}. Thẻ đẩy sang {chargingTran.ProviderCode} gửi sang nhóm đó để kiểm tra. ");

                            if (chargingTran.ProviderCode == "CIUCIU")
                            {
                                //ciuciu -493773906
                                bot.SendTextMessageAsync("-493773906", $"Kiểm tra giúp mình serial {chargingTran.CardSerial},\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                            }
                            else if
                            (chargingTran.ProviderCode == "XBOOM")
                            {
                                //xboom -351143187
                                bot.SendTextMessageAsync("-212144332", $"Kiểm tra giúp mình serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                            }
                            else if
                            (chargingTran.ProviderCode == "ZINZIN")
                            {
                                //zinzin -422675811
                                bot.SendTextMessageAsync("-422675811", $"Kiểm tra giúp mình serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                            }
                            else if
                            (chargingTran.ProviderCode == "BK")
                            {
                                //BK -532189221
                            bot.SendTextMessageAsync("-532189221", $"Kiểm tra giúp mình serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                            }
                        }
                        else if (chargingTran.CardType != 1)
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhân được thẻ serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}.\nA/c đợi bên em kiểm tra rồi phản hồi lại @mrtelesupport. ");
                        }
                        else
                        {
                            var checkCardList = _checkCardTransactionRepository.GetCheckCard(serial);
                            var checkMobile = _chargingTopupTransactionRepository.GetChargingTopupTran(chargingTran);
                            var a = 0;

                            var checkCard = new CheckCardTransaction();
                            checkCard = null;

                            var isExistUsedCard = checkCardList.Where(c => c.Status == 1 && c.CardStatus == 1).FirstOrDefault();
                            if (isExistUsedCard != null)
                            {
                                checkCard = isExistUsedCard;
                            }
                            //var isExistNotFoundCard = checkCardList.Where(c => c.Status == 13 && c.CardStatus == 13).FirstOrDefault();
                            //if (isExistNotFoundCard != null)
                            //{
                            //    checkCard = isExistNotFoundCard;
                            //}

                            var isExistWrongSerialCard = checkCardList.Where(c => c.Status == 1 && c.CardStatus == 13).FirstOrDefault();
                            if (isExistWrongSerialCard != null)
                            {
                                checkCard = isExistWrongSerialCard;
                            }

                            if (checkCard == null)
                            {
                                var addCard = _checkCardTransactionRepository.InsertCheckCard(serial, (byte)chargingTran.CardType);
                                do
                                {
                                    _LOG.Info($"GetAddCard: {addCard.ToJson()}");
                                    checkCard = _checkCardTransactionRepository.GetCheckCardSuccess((int)addCard.Id);

                                    if (checkCard != null || a >= 6)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Thread.Sleep(8000);
                                    }
                                    a++;
                                }
                                while (a <= 6);
                            }

                            if (checkCard != null)
                            {
                                if (chargingTran.Status == 2 && checkMobile.WorkerChannel == "USSD199_FTTH")
                                {   //TH 199, FTTH
                                    Console.WriteLine("FTTH");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhân được thẻ serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}.\nA/c đợi bên em kiểm tra rồi phản hồi lại @mrtelesupport. ");
                                }
                                else if (checkCard.Status == 1 && checkCard.CardStatus == 13)
                                {  //TH k tim thay thong tin the cao
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhân được thẻ serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}.\nSerial này check nhà mạng báo không tìm thấy thông tin thẻ cào, a/c kiểm tra lại giúp. ");
                                }
                                else if (checkCard.Status == 1 && checkCard.UseTime < chargingTran.CreatedTime)
                                {   //TH the sd truoc

                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được thẻ serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}\nTrạng thái: {Constant.CARDSTATUS[(byte)chargingTran.Status]}\nGhi chú: serial kiểm tra đã sử dụng trước khi gửi qua hệ thống bên em.\nThuê bao: {checkCard.Isdn}\nThời gian: {checkCard.UseTime}\nMệnh giá: {checkCard.CardAmount}.");
                                }
                                else if (checkCard.Status == 1 && checkCard.CardStatus == 0)
                                {   //TH sai mã
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được thẻ serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}\nTrạng thái: {Constant.CARDSTATUS[(byte)chargingTran.Status]}\nGhi chú: serial kiểm tra chưa sử dụng, mã thẻ sai, a/c kiểm tra lại giúp e.");

                                }
                                else if (checkCard.Status == 1 && chargingTran.Status == 2 && checkCard.Isdn.Substring(0, 5) != checkMobile.Mobile.Substring(1, 5))
                                {   //TH tb nap k phai ben minh
                                    Console.WriteLine("tb nap k co trong ht");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được thẻ serial: {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}\nTrạng thái: {Constant.CARDSTATUS[(byte)chargingTran.Status]}\nGhi chú: thuê bao sử dụng không có trên hệ thống bên em.\nThuê bao: {checkCard.Isdn}\nThời gian: {checkCard.UseTime}\nMệnh giá: {checkCard.CardAmount}");
                                }
                                else if (checkCard.CardStatus == 13 && checkCard.CardStatus == 13)
                                {   //TH qua so lan tra cuu
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhân được thẻ serial {chargingTran.CardSerial}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nMệnh giá gửi: {chargingTran.RequestAmount}.\nA/c đợi bên em kiểm tra rồi phản hồi lại @mrtelesupport. ");
                                }

                            }


                        }
                    }
                    else
                    {   //the k tim thay
                        bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial {serial} không tìm thấy trên HT bên em, a/c kiểm tra lại giúp. ");
                    }

                }

            
            }
        private static void CheckSaiDung(Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text.StartsWith("/sai"))
            {

                var listPartnerCode = _partnerRepository.GetListPartnerByTelegramGroupId(e.Message.Chat.Id.ToString());

                var userInput = e.Message.Text;
                userInput = userInput.Replace("/sai", " ").Replace("/dung", " ").Replace("dung", " ").Replace("/ dung", " ").Replace("/ sai", " ");
                List<string> list = userInput.Split(' ').ToList();

                list = list.Where(a => a.Length > 0).ToList();
                //Console.WriteLine(a);
                var serialSai = list[0];
                var serialDung = list[1];

                if (list.Count == 2) // co the check them dinh dang serial dung
                {

                    var chargingTran = _chargingTransactionRepository.GetTransactionBySerialFalsePartnerCode(serialSai, listPartnerCode);
                    if (chargingTran != null)
                    {
                        _LOG.Info($"GetChargingTran: {chargingTran.ToJson()}");
                        // Tra loi khach dang kiem tra serial dung, doi em them 1 chut.


                        //Neu provider la payexpress va interner error !- 6
                        if (chargingTran.InternalErrorCode != 6 & (chargingTran.ProviderCode == "PAYEXPRESS" || chargingTran.ProviderCode == "THANHTOANVIP"))
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial sai: {serialSai}\nSerial {serialSai} đang không phải trạng thái sai serial. A/c đợi chút bên em check rồi trả kết quả ạ.");


                            CheckSerial(e);
                            return;

                        }
                        if (chargingTran.CardSerial == serialDung)
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial đúng: {serialDung} giống serial sai: {serialSai}, a/c kiểm tra lại giúp em. ");
                            return;
                        }

                        bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial đúng: {serialDung}.\nA/c đợi 1 chút bên em kiểm tra và trả lời kết quả ạ. ");


                        if (chargingTran.InternalErrorCode == 6)
                        {

                            var addCard = _checkCardTransactionRepository.InsertCheckCard(serialDung, (byte)chargingTran.CardType);

                            if (addCard == null)
                            {
                                // Tag support loi khong insert dc check the
                                bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial: {serialSai}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nSerial đúng: {serialDung}.\nA/c đợi bên em kiểm tra rồi phản hồi lại @mrtelesupport.");
                                return;
                            }

                            var checkMobile = _chargingTopupTransactionRepository.GetChargingTopupTran(chargingTran);
                            var a = 0;
                            var checkCardTran = new CheckCardTransaction();

                            do
                            {

                                addCard = _checkCardTransactionRepository.GetCheckCardSerialDung(serialDung);

                                Console.WriteLine("add serial sai");
                                if (addCard.Status == 1 || a >= 6)
                                {
                                    Console.WriteLine("add serial sai tc");

                                    break;
                                }
                                else
                                {
                                    Thread.Sleep(10000);
                                }
                                a++;
                            }
                            while (a < 6);

                            if (addCard != null)
                            {
                                _LOG.Info($"CheckaddCardSerialFailse: {addCard.ToJson()}");
                                Console.WriteLine("Check");
                                if (addCard.Status == 1 && addCard.CardStatus == 1 && addCard.Isdn.Substring(0, 5) == checkMobile.Mobile.Substring(1, 5))
                                {
                                    //TH dung so nap
                                    Console.WriteLine("Dung so nap");
                                    var update = _chargingTransactionRepository.UpdateSerialFalse(chargingTran, 1, (int)addCard.CardAmount);
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial sai: {serialSai}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nSerial đúng: {serialDung}\nTrạng thái: THÀNH CÔNG\nMệnh giá nạp: {addCard.CardAmount}\nĐã thực hiện lại callback lần nữa, a/c kiểm tra lại giúp. ");
                                }
                                else if (addCard.Status == 1 && addCard.CardStatus == 1 && addCard.Isdn.Substring(0, 5) != checkMobile.Mobile.Substring(1, 5))
                                {   //TH khac so nap
                                    Console.WriteLine("sai so nap");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial sai: {serialSai}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nSerial đúng: {serialDung} bên mình cung cấp không nạp vào thuê bao bên em. A/c kiểm tra lại giúp em.");
                                }
                                else if (addCard.Status == 1 && addCard.CardStatus == 0)
                                {
                                    Console.WriteLine("serial dung tham so k hop le");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial sai: {serialSai}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nSerial đúng: {serialDung} bên mình cung cấp chưa sử dụng. A/c kiểm tra lại giúp em.");
                                }
                                else if (addCard.Status == 13 && addCard.Status == 13)
                                {
                                    //TH seri đúng check quá số lần
                                    Console.WriteLine("qua so lan tra cuu");
                                    bot.SendTextMessageAsync("-572467985", $"Serial sai: {serialSai} serial đúng: {serialDung}, nhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}, mệnh giá gửi: {chargingTran.RequestAmount}, đối tác: {chargingTran.PartnerCode}. Kiểm tra serial đúng sai vì quá số lần tra cứu.  ");
                                    // Gui thong bao cho nhom van hanh no bot
                                }
                                else if (addCard.Status == 1 && addCard.CardStatus == 13)
                                {
                                    Console.WriteLine("serial dung khong tim thay thong tin ");
                                    bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial đúng: {serialDung} bên mình cung cấp check không tìm thấy thông tin thẻ cào. A/c kiểm tra lại giúp ");
                                }

                            }
                        }
                        else if (chargingTran.InternalErrorCode != 6)
                        {
                            if (chargingTran.ProviderCode != "PAYEXPRESS" && chargingTran.ProviderCode != "THANHTOANVIP")
                            {
                                bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial sai: {serialSai}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]}\nSerial đúng: {serialDung}\nA/c đợi chút bên em kiểm tra rồi trả kết quả ạ. ");

                                if (chargingTran.ProviderCode == "CIUCIU")
                                {
                                    //ciuciu -493773906
                                    bot.SendTextMessageAsync("-493773906", $"Kiểm tra giúp mình serial sai: {serialSai}\nSerial đúng: {serialDung}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                                }
                                else if
                                (chargingTran.ProviderCode == "XBOOM")
                                {
                                    //xboom -351143187
                                    bot.SendTextMessageAsync("-212144332", $"Kiểm tra giúp mình serial sai: {serialSai}\nSerial đúng: {serialDung}\nNhà mạng: {Constant.CARDTYPESERIAL[(byte)chargingTran.CardType]} ");
                                }
                            }
                        }
                        else
                        {
                            bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Bên em đã nhận được serial sai: {serialSai} serial đúng: {serialDung}.\nA/c đợi 1 chút bên em kiểm tra và trả lời kết quả @mrtelesupport. ");
                        }
                    }
                    else
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id.ToString(), $"Serial sai: {serialSai} không tìm thấy trên hệ thống bên em, a/c kiểm tra lại giúp.");
                    }

                }
            }
        }
        private static void TopupTrans()
        {
            var partnerCode = "ZOTA";
            int Status = 13;
            do
            {
                var topupTran = _topupTransactionRepository.GetTopupTransactinon(partnerCode, Status);
                if (topupTran.Status == 13)
                {
                    bot.SendTextMessageAsync("-1001180320054", $" Mã GD: {topupTran.TransCode} Thành Công Sai Serial SĐT: {topupTran.Mobile} Yêu cầu cập nhật lại.");
                    Thread.Sleep(5000);
                }
            } while (true);
        }
        //    private static void PinCode(object sender, Telegram.Bot.Args.MessageEventArgs e)
        //    {
        //        Console.WriteLine("Pincode");
        //        _pincodeService.GetPinCodeStock(sender, e, bot);
        //    }

        //}

    }
}



