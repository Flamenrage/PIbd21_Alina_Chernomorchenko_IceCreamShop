using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;
using IceCreamShopServiceDAL.Enums;

namespace IceCreamShopServiceImplement.Implements
{
    public class BookingServiceList: IBookingService
    {
        private readonly DataListSingleton source;
        public  BookingServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(BookingBindingModel model)
        {
            Booking tempBooking = model.Id.HasValue ? null : new Booking
            {
                Id = 1
            };
            foreach (var Booking in source.Bookings)
            {
                if (!model.Id.HasValue && Booking.Id >= tempBooking.Id)
                {
                    tempBooking.Id = Booking.Id + 1;
                }
                else if (model.Id.HasValue && Booking.Id == model.Id)
                {
                    tempBooking = Booking;
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
                    if (booking.Id == model.Id && booking.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(booking));
                        break;
                    }
                    else if (model.DateFrom.HasValue && model.DateTo.HasValue && booking.DateCreate >= model.DateFrom &&
                        booking.DateCreate <= model.DateTo)
                        result.Add(CreateViewModel(booking));
                    else if (model.ClientId.HasValue && booking.ClientId == model.ClientId)
                        result.Add(CreateViewModel(booking));
                    else if (model.FreeOrder.HasValue && model.FreeOrder.Value && !(booking.ImplementerFIO != null))
                        result.Add(CreateViewModel(booking));
                    else if (model.ImplementerId.HasValue && booking.ImplementerId == model.ImplementerId.Value && booking.Status == BookingStatus.Выполняется)
                        result.Add(CreateViewModel(booking));
                    continue;
                }
                result.Add(CreateViewModel(booking));
            }
            return result;
        }
        private Booking CreateModel(BookingBindingModel model, Booking booking)
        {
            booking.Count = model.Count;
            booking.DateCreate = model.DateCreate;
            booking.ClientId = model.ClientId.Value;
            booking.ClientFIO = model.ClientFIO;
            booking.DateImplement = model.DateImplement;
            booking.ImplementerId = model.ImplementerId;
            booking.ImplementerFIO = model.ImplementerFIO;
            booking.IceCreamId = model.IceCreamId;
            booking.Status = model.Status;
            booking.Sum = model.Sum;
            return booking;
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
                ClientId = booking.ClientId,
                ClientFIO = booking.ClientFIO,
                ImplementorId = booking.ImplementerId,
                ImplementerFIO = booking.ImplementerFIO,
                IceCreamId = booking.IceCreamId,
                Status = booking.Status,
                Sum = booking.Sum
            };
        }
    }
}
