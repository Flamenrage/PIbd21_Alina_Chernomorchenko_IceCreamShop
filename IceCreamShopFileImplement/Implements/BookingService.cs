using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopFileImplement.Models;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;

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
            element.Count = model.Count;
            element.Sum = model.Sum;
            element.Status = model.Status;
            element.DateCreate = model.DateCreate;
            element.DateImplement = model.DateImplement;
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
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                IceCreamName = GetIceCreamName(rec.IceCreamId),
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            })
            .ToList();
        }

        private string GetIceCreamName(int id)
        {
            string name = "";
            var IceCream = source.IceCreams.FirstOrDefault(x => x.Id == id);
            name = IceCream != null ? IceCream.IceCreamName : "";
            return name;
        }
    }
}