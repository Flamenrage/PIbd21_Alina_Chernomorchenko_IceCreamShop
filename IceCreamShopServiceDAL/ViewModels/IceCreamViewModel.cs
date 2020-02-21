using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class IceCreamViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название мороженого")]
        public string IceCreamName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> IceCreamIngredients { get; set; }
    }
}
