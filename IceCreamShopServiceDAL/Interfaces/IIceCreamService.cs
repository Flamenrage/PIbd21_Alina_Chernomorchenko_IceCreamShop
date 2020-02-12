using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IIceCreamService
    {
        List<IceCreamViewModel> GetList();
        IceCreamViewModel GetElement(int id);
        void AddElement(IceCreamBindingModel model);
        void UpdElement(IceCreamBindingModel model);
        void DelElement(int id);
    }
}
