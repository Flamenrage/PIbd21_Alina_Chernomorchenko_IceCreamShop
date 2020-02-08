using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    interface IMainService
    {
        List<BookingViewModel> GetBookings();
        void CreateBooking(BookingBindingModel model);
        void TakeBookingInWork(BookingBindingModel model);
        void FinishBooking(BookingBindingModel model);
        void PayBooking(BookingBindingModel model);
    }
}
