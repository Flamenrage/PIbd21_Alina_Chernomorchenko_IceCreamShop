using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class IceCreamIngredientViewModel
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        public int IngredientId { get; set; }
        [DisplayName("Ингредиент")]
        public string IngredientName{ get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
