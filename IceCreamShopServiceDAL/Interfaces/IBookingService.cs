using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceDAL.BindingModels;
using System.Collections.Generic;


namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IBookingService
    {
        List<BookingViewModel> Read(BookingBindingModel model);
        void CreateOrUpdate(BookingBindingModel model);
        void Delete(BookingBindingModel model);
    }
}
