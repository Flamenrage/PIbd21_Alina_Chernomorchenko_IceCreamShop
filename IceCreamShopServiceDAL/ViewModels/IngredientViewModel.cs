using IceCreamShopServiceDAL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class IngredientViewModel : BaseViewModel
    {
        [Column(title: "Название ингредиента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string IngredientName { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "IngredientName" };
    }
}
