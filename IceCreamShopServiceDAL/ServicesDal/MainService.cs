using IceCreamShopServiceDAL.Enums;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using System.Collections.Generic;
using System;

namespace IceCreamShopServiceDAL.ServicesDal
{
   public class MainService
    {
        private readonly IBookingService BookingService;
        private readonly IStorageLogic storageLogic;

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
                Status = BookingStatus.Принят
            });
        }
        public void TakeBookingInWork(ChangeStatusBindingModel model)
        {
            var Booking = BookingService.Read(new BookingBindingModel
            {
                Id = model.BookingId 
            })?[0];
            if (Booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (Booking.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            Console.WriteLine($"Take booking with id {Booking.Id} and IceCream id {Booking.IceCreamId}");
            storageLogic.RemoveFromStorage(Booking.IceCreamId, Booking.Count);
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                Id = Booking.Id,
                IceCreamId = Booking.IceCreamId,
                Count = Booking.Count,
                Sum = Booking.Sum,
                DateCreate = Booking.DateCreate,
                DateImplement = DateTime.Now,
                Status = BookingStatus.Выполняется
            });
        }

        public void FinishBooking(ChangeStatusBindingModel model) {
             var Booking = BookingService.Read(new BookingBindingModel
             {
                 Id = model.BookingId
             })?[0];
             if (Booking == null)
             {
                throw new Exception("Не найден заказ");
             }
             if (Booking.Status != BookingStatus.Выполняется)
             {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
             }
             BookingService.CreateOrUpdate(new BookingBindingModel
             {
                 Id = Booking.Id,
                 IceCreamId = Booking.IceCreamId,
                 Count = Booking.Count,
                 Sum = Booking.Sum,
                 DateCreate = Booking.DateCreate,
                 DateImplement = Booking.DateImplement,
                 Status = BookingStatus.Готов
             });
            }
         public void PayBooking(ChangeStatusBindingModel model)
        {
            var Booking = BookingService.Read(new BookingBindingModel
            {
                Id = model.BookingId
            })?[0];
            if (Booking == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (Booking.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            BookingService.CreateOrUpdate(new BookingBindingModel
            {
                Id = Booking.Id,
                IceCreamId = Booking.IceCreamId,
                Count = Booking.Count,
                Sum = Booking.Sum,
                DateCreate = Booking.DateCreate,
                DateImplement = Booking.DateImplement,
                Status = BookingStatus.Оплачен
            });
        }
        public void FillStorage(StorageIngredientBindingModel model)
        {
            storageLogic.FillStorage(model);
        }
    }
}