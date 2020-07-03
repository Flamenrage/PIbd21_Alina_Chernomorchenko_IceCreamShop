using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IIceCreamService
    {
        List<IceCreamViewModel> Read(IceCreamBindingModel model);
        void CreateOrUpdate(IceCreamBindingModel model);
        void Delete(IceCreamBindingModel model);
    }
}
