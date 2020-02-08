using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class IceCreamIngredientBindingModel
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public int Count { get; set; }
    }
}
