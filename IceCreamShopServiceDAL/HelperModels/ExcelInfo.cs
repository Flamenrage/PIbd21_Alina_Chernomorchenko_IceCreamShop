using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportIceCreamIngredientViewModel> IceCreamIngredients { get; set; }
        public List<ReportBookingsViewModel> Bookings { get; set; }
    }
}
