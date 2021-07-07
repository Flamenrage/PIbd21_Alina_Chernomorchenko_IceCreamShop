using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopFileImplement.Models;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using IceCreamShopServiceDAL.Enums;

namespace IceCreamShopFileImplement.Implements
{
    public class BookingService: IBookingService
    {
        private readonly FileDataListSingleton source;
        public BookingService()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(BookingBindingModel model)
        {
            Booking element;
            if (model.Id.HasValue)
            {
                element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Bookings.Count > 0 ? source.Bookings.Max(rec =>
               rec.Id) : 0;
                element = new Booking { Id = maxId + 1 };
                source.Bookings.Add(element);
            }
            element.IceCreamId = model.IceCreamId == 0 ? element.IceCreamId : model.IceCreamId;
            element.ClientId = model.ClientId.Value;
            element.Count = model.Count;
            element.DateCreate = model.DateCreate;
            element.ImplementerId = model.ImplementerId;
            element.DateImplement = model.DateImplement;
            element.Status = model.Status;
            element.Sum = model.Sum;
        }
        public void Delete(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Bookings.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<BookingViewModel> Read(BookingBindingModel model)
        {
            return source.Bookings
                  .Where(rec => model == null 
                  || (model.Id.HasValue && rec.Id == model.Id && rec.ClientId == model.ClientId)
                  || (model.DateTo.HasValue && model.DateFrom.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo) 
                  || (model.ClientId.HasValue && rec.ClientId == model.ClientId) 
                  || (model.FreeOrder.HasValue && model.FreeOrder.Value && !rec.ImplementerId.HasValue) 
                  || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == BookingStatus.Выполняется))
            .Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                IceCreamId = rec.IceCreamId,
                IceCreamName = source.IceCreams.FirstOrDefault(r => r.Id == rec.IceCreamId)?.IceCreamName,
                ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id == rec.ClientId)?.ClientFIO,
                ClientId = rec.ClientId,
                ImplementorId = rec.ImplementerId,
                ImplementerFIO = source.Implementers.FirstOrDefault(x => x.Id == rec.ImplementerId)?.ImplementerFIO,
                Count = rec.Count,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status,
                Sum = rec.Sum
            })
            .ToList();
        }
    }
}