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
        private readonly object locker = new object();


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
            lock (locker)
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
                if (booking.ImplementorId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
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
                    ImplementerFIO = model.ImplementerFIO,
                    ImplementerId = model.ImplementerId.Value,
                    ClientFIO = booking.ClientFIO
                });
		        Console.WriteLine($"Take booking with id {booking.Id} and IceCream id {booking.IceCreamId}");
		        try
		        {
		            storageLogic.RemoveFromStorage(booking);
		            BookingService.CreateOrUpdate(new BookingBindingModel
		            {
		                Id = booking.Id,
		                IceCreamId = booking.IceCreamId,
		                Count = booking.Count,
		                Sum = booking.Sum,
		                DateCreate = booking.DateCreate,
		                DateImplement = null,
		                Status = BookingStatus.Выполняется,
		                ImplementerFIO = model.ImplementerFIO,
		                ImplementerId = model.ImplementerId.Value,
		                ClientId = booking.ClientId,
		                ClientFIO = booking.ClientFIO
		            });
		        }
		        catch (Exception)
		        {
		            throw;
		        }
            }
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
                ImplementerFIO = booking.ImplementerFIO,
                ImplementerId = booking.ImplementorId.Value,
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
                ImplementerFIO = booking.ImplementerFIO,
                ImplementerId = booking.ImplementorId.Value, 
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