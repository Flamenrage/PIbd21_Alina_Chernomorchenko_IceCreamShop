using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IStorageLogic
    {
        List<StorageViewModel> GetList();
        StorageViewModel GetElement(int id);
        void AddElement(StorageBindingModel model);
        void UpdElement(StorageBindingModel model);
        void DelElement(int id);
        void FillStorage(StorageIngredientBindingModel model);
        void RemoveFromStorage(int icecreamId, int icecreamsCount);
    }
}
