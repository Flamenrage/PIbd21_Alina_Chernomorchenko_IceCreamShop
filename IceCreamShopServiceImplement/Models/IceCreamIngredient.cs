using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceImplement.Models
{
    public class IceCreamIngredient
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
