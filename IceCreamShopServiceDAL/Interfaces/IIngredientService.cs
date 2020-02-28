using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System.Collections.Generic;

namespace IceCreamShopServiceDAL.Interfaces
{
    public interface IIngredientService
    {
        List<IngredientViewModel> Read(IngredientBindingModel model);
        void CreateOrUpdate(IngredientBindingModel model);
        void Delete(IngredientBindingModel model);
    }
}
