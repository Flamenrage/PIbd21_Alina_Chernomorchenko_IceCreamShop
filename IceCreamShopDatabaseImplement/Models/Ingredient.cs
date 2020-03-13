using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace IceCreamShopDatabaseImplement.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required]
        public string IngredientName { get; set; }
        [ForeignKey("IngredientId")]
        public virtual List<IceCreamIngredient> IceCreamIngredients { get; set; }
    }
}
