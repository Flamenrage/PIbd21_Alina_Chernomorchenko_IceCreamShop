using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopRestApi.Models
{
    public class StorageModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageIngredientViewModel> StorageIngredients { get; set; }
    }
}
