using IceCreamShopServiceDAL.Enums;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System.Collections.Generic;
using System;
using IceCreamShopServiceDAL.HelperModels;

namespace IceCreamShopServiceDAL.ServicesDal
{
   public class MainService
    {
        private readonly IBookingService bookingLogic;
        private readonly IClientLogic clientLogic;
        private readonly object locker = new object();

        public MainService(IBookingService bookingLogic, IClientLogic clientLogic)
        {
            this.bookingLogic = bookingLogic;
            this.clientLogic = clientLogic;
        }
        public void CreateBooking(CreateBookingBindingModel model)
        {
            bookingLogic.CreateOrUpdate(new BookingBindingModel
            {
                IceCreamId = model.IceCreamId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = BookingStatus.Принят,
                ClientFIO = model.ClientFIO,
                ClientId = model.ClientId
            });
            MailLogic.SendMail(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel { Id = model.ClientId })?[0]?.Login,
                Subject = $"Новый заказ",
                Text = $"Заказ принят."
            });
        }
        public void TakeBookingInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var booking = bookingLogic.Read(new BookingBindingModel { Id = model.BookingId })?[0];
                if (booking == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (booking.Status != BookingStatus.Принят)
                {
                    throw new Exception("Заказ не в статусе \"Принят\"");
                }
                if (booking.ImplementorId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                bookingLogic.CreateOrUpdate(new BookingBindingModel
                {
                    Id = booking.Id,
                    IceCreamId = booking.IceCreamId,
                    Count = booking.Count,
                    Sum = booking.Sum,
                    DateCreate = booking.DateCreate,
                    DateImplement = null,
                    Status = BookingStatus.Выполняется,
                    ClientId = booking.ClientId,
                    ImplementerFIO = model.ImplementerFIO,
                    ImplementerId = model.ImplementerId.Value,
                    ClientFIO = booking.ClientFIO
                });
                MailLogic.SendMail(new MailSendInfo
                {
                    MailAddress = clientLogic.Read(new ClientBindingModel { Id = booking.ClientId })?[0]?.Login,
                    Subject = $"Заказ №{booking.Id}",
                    Text = $"Заказ №{booking.Id} передан в работу."
                });
            }
        }
        public void FinishBooking(ChangeStatusBindingModel model)
        {
            var booking = bookingLogic.Read(new BookingBindingModel { Id = model.BookingId })?[0];
            if (booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (booking.Status != BookingStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            bookingLogic.CreateOrUpdate(new BookingBindingModel
            {
                Id = booking.Id,
                IceCreamId = booking.IceCreamId,
                Count = booking.Count,
                ImplementerFIO = booking.ImplementerFIO,
                ImplementerId = booking.ImplementorId.Value,
                Sum = booking.Sum,
                DateCreate = booking.DateCreate,
                DateImplement = DateTime.Now,
                Status = BookingStatus.Готов,
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO
            });
            MailLogic.SendMail(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel { Id = booking.ClientId })?[0]?.Login,
                Subject = $"Заказ №{booking.Id}",
                Text = $"Заказ №{booking.Id} готов."
            });
        }
        public void PayBooking(ChangeStatusBindingModel model)
        {
            var booking = bookingLogic.Read(new BookingBindingModel { Id = model.BookingId })?[0];
            if (booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (booking.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            bookingLogic.CreateOrUpdate(new BookingBindingModel
            {
                Id = booking.Id,
                IceCreamId = booking.IceCreamId,
                Count = booking.Count,
                Sum = booking.Sum,
                DateCreate = booking.DateCreate,
                ImplementerFIO = booking.ImplementerFIO,
                ImplementerId = booking.ImplementorId.Value, 
                DateImplement = booking.DateImplement,
                Status = BookingStatus.Оплачен,
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO
            });
            MailLogic.SendMail(new MailSendInfo
            {
                MailAddress = clientLogic.Read(new ClientBindingModel { Id = booking.ClientId })?[0]?.Login,
                Subject = $"Заказ №{booking.Id}",
                Text = $"Заказ №{booking.Id} оплачен."
            });
        }
    }
}