using IceCreamShopServiceDAL.Enums;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System.Collections.Generic;
using System;

namespace IceCreamShopServiceDAL.ServicesDal
{
   public class MainService
    {
        private readonly IStorageLogic storageLogic;
        private readonly IBookingService BookingService;

        public MainService(IBookingService BookingService, IStorageLogic storageLogic)
        {
            this.BookingService = BookingService;
            this.storageLogic = storageLogic;
        }

        public void CreateBooking(CreateBookingBindingModel model)
        {
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                IceCreamId = model.IceCreamId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = BookingStatus.Принят,
                ClientFIO = model.ClientFIO,
                ClientId = model.ClientId
            });
        }
        public void TakeBookingInWork(ChangeStatusBindingModel model)
        {
            var booking = BookingService.Read(new BookingBindingModel { Id = model.BookingId })?[0];
            if (booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (booking.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            Console.WriteLine($"Take booking with id {Booking.Id} and IceCream id {Booking.IceCreamId}");
            storageLogic.RemoveFromStorage(Booking.IceCreamId, Booking.Count);
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                Id = booking.Id,
                IceCreamId = booking.IceCreamId,
                Count = booking.Count,
                Sum = booking.Sum,
                DateCreate = booking.DateCreate,
                DateImplement = null,
                Status = BookingStatus.Выполняется,
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO
            });
        }
        public void FinishBooking(ChangeStatusBindingModel model)
        {
            var booking = BookingService.Read(new BookingBindingModel { Id = model.BookingId })?[0];
            if (booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (booking.Status != BookingStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                Id = booking.Id,
                IceCreamId = booking.IceCreamId,
                Count = booking.Count,
                Sum = booking.Sum,
                DateCreate = booking.DateCreate,
                DateImplement = DateTime.Now,
                Status = BookingStatus.Готов,
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO
            });
        }
        public void PayBooking(ChangeStatusBindingModel model)
        {
            var booking = BookingService.Read(new BookingBindingModel { Id = model.BookingId })?[0];
            if (booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (booking.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                Id = booking.Id,
                IceCreamId = booking.IceCreamId,
                Count = booking.Count,
                Sum = booking.Sum,
                DateCreate = booking.DateCreate,
                DateImplement = booking.DateImplement,
                Status = BookingStatus.Оплачен,
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO
            });
        }
        public void FillStorage(StorageIngredientBindingModel model)
        {
            storageLogic.FillStorage(model);
        }
    }
}