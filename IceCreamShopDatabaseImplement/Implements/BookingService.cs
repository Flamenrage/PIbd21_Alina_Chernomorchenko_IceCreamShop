using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IceCreamShopServiceDAL.Enums;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class BookingService : IBookingService
    {

        public void CreateOrUpdate(BookingBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                Booking element;
                if (model.Id.HasValue)
                {
                    element = context.Bookings.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Booking();
                    context.Bookings.Add(element);
                }
                element.IceCreamId = model.IceCreamId == 0 ? element.IceCreamId : model.IceCreamId;
                element.ClientId = model.ClientId.Value;
                element.ImplementerId = model.ImplementerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }
        public void Delete(BookingBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Bookings.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<BookingViewModel> Read(BookingBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                return context.Bookings.Where(rec => model == null 
                || (rec.Id == model.Id)
                || ((rec.DateCreate >= model.DateFrom) && (rec.DateCreate <= model.DateTo))
                || (model.ClientId == rec.ClientId) 
                || (model.FreeOrder.HasValue && model.FreeOrder.Value && !rec.ImplementerId.HasValue) 
                || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value && rec.Status == BookingStatus.Выполняется))
            .Include(ord => ord.IceCream)
        .Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                IceCreamId = rec.IceCreamId,
                IceCreamName = rec.IceCream.IceCreamName,
                ClientFIO = rec.Client.ClientFIO,
                ClientId = rec.ClientId,
                Count = rec.Count,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status,
                Sum = rec.Sum,
                ImplementorId = rec.ImplementerId,
                ImplementerFIO = rec.Implementer.ImplementerFIO
            })
            .ToList();
            }
        }
    }
}
