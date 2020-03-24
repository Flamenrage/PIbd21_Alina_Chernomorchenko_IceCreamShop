using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }
}
