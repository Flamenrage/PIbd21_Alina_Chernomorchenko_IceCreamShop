using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;

namespace IceCreamShopServiceImplement.Implements
{
    public class BookingServiceList: IBookingService
    {
        private readonly DataListSingleton source;
        public  BookingServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate( BookingBindingModel model)
        {
             Booking tempBooking = model.Id.HasValue ? null : new Booking { Id = 1 };
            foreach (var booking in source.Bookings)
            {
                if (booking.DateCreate == model.DateCreate && booking.Count == model.Count &&
                    booking.IceCreamId == model.IceCreamId && booking.Sum == model.Sum &&
                    booking.Status == model.Status && booking.Id != model.Id)
                {
                    throw new Exception("Такой заказ уже существует");
                }
                if (!model.Id.HasValue && booking.Id >= tempBooking.Id)
                {
                    tempBooking.Id = booking.Id + 1;
                }
                else if (model.Id.HasValue && booking.Id == model.Id)
                {
                    tempBooking = booking;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempBooking == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempBooking);
            }
            else
            {
                source.Bookings.Add(CreateModel(model, tempBooking));
            }
        }
        public void Delete(BookingBindingModel model)
        {
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id == model.Id.Value)
                {
                    source.Bookings.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<BookingViewModel> Read(BookingBindingModel model)
        {
            List<BookingViewModel> result = new List<BookingViewModel>();
            foreach (var booking in source.Bookings)
            {
                if (model != null)
                {
                    if (booking.Id == model.Id)
                    {
                        result.Add(CreateViewModel(booking));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(booking));
            }
            return result;
        }
        private Booking CreateModel(BookingBindingModel model, Booking ingredient)
        {
            ingredient.Count = model.Count;
            ingredient.DateCreate = model.DateCreate;
            ingredient.DateImplement = model.DateImplement;
            ingredient.IceCreamId = model.IceCreamId;
            ingredient.Status = model.Status;
            ingredient.Sum = model.Sum;
            return ingredient;
        }
        private BookingViewModel CreateViewModel(Booking booking)
        {
            string icecreamName = "";
            foreach (var icecream in source.IceCreams)
            {
                if (icecream.Id == booking.IceCreamId)
                {
                    icecreamName = icecream.IceCreamName;
                    break;
                }
            }
            return new BookingViewModel
            {
                Id = booking.Id,
                Count = booking.Count,
                DateCreate = booking.DateCreate,
                DateImplement = booking.DateImplement,
                IceCreamName = icecreamName,
                IceCreamId = booking.IceCreamId,
                Status = booking.Status,
                Sum = booking.Sum
            };
        }
    }
}
