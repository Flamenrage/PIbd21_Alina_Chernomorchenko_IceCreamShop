using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class ReportIceCreamIngredientViewModel
    {
        public string IngredientName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> IceCreams { get; set; }
    }
}
