using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class StorageIngredientViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int IngredientId  { get; set; }
        [DisplayName("Название ингредиента")]
        public string IngredientName { get; set; }
        [DisplayName("Количество")]  
        public int Count { get; set; }
    }
}
