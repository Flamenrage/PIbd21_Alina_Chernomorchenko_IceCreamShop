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
                    if ((model.Id.HasValue && booking.Id == model.Id)
                        || (model.DateFrom.HasValue && model.DateTo.HasValue && booking.DateCreate >= model.DateFrom && booking.DateCreate <= model.DateTo)
                        || (booking.ClientId == model.ClientId)
                        || (model.FreeOrder.HasValue && model.FreeOrder.Value && !booking.ImplementerId.HasValue)
                        || (model.ImplementerId.HasValue && booking.ImplementerId == model.ImplementerId && booking.Status == BookingStatus.Выполняется))
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
        private Booking CreateModel(BookingBindingModel model, Booking booking)
        {
            IceCream icecream = null;

            foreach (IceCream i in source.IceCreams)
            {
                if (i.Id == model.IceCreamId)
                {
                    icecream = i;
                    break;
                }
            }

            Client client = null;

            foreach (Client c in source.Clients)
            {
                if (c.Id == model.ClientId)
                {
                    client = c;
                    break;
                }
            }

            Implementer implementer = null;

            foreach (Implementer i in source.Implementers)
            {
                if (i.Id == model.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }

            if (icecream == null || client == null || model.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }

            booking.IceCreamId = model.IceCreamId;
            booking.ClientId = model.ClientId.Value;
            booking.ClientFIO = client.ClientFIO;
            booking.ImplementerId = (int)model.ImplementerId;
            booking.ImplementerFIO = implementer.ImplementerFIO;
            booking.Count = model.Count;
            booking.Sum = model.Count * icecream.Price;
            booking.Status = model.Status;
            booking.DateCreate = model.DateCreate;
            booking.DateImplement = model.DateImplement;
            return booking;
        }
        private BookingViewModel CreateViewModel(Booking booking)
        {
            IceCream icecream = null;

            foreach (IceCream ice in source.IceCreams)
            {
                if (ice.Id == booking.IceCreamId)
                {
                    icecream = ice;
                    break;
                }
            }

            Client client = null;

            foreach (Client c in source.Clients)
            {
                if (c.Id == booking.ClientId)
                {
                    client = c;
                    break;
                }
            }

            Implementer implementer = null;

            foreach (Implementer i in source.Implementers)
            {
                if (i.Id == booking.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }

            if (icecream == null || client == null || booking.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }

            return new BookingViewModel
            {
                Id = booking.Id,
                Count = booking.Count,
                DateCreate = booking.DateCreate,
                DateImplement = booking.DateImplement,
                IceCreamName = icecream.IceCreamName,
                ClientId = booking.ClientId,
                ClientFIO = client.ClientFIO,
                ImplementorId = booking.ImplementerId,
                ImplementerFIO = implementer.ImplementerFIO,
                IceCreamId = booking.IceCreamId,
                Status = booking.Status,
                Sum = booking.Sum
            };
        }
    }
}
