using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IceCreamShopDatabaseImplement.Models
{
    public class StorageIngredient
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int IngredientId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
