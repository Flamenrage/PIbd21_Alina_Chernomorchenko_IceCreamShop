using System;
using System.Collections.Generic;
using System.Text;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceDAL.BindingModels;

namespace IceCreamShopServiceDAL.Interfaces
{
   public interface IClientLogic
    {
        List<ClientViewModel> Read(ClientBindingModel model);
        void CreateOrUpdate(ClientBindingModel model);
        void Delete(ClientBindingModel model);
    }
}
