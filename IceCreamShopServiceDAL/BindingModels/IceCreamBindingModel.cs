using System.Collections.Generic;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class IceCreamBindingModel
    {
        public int Id { get; set; }
        public string IceCreamName { get; set; }
        public decimal Price { get; set; }
        public List<IceCreamIngredientBindingModel> IceCreamIngredients { get; set; }
    }
}
