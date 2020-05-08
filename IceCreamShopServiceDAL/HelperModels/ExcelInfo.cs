using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IceCreamShopServiceDAL.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IGrouping<DateTime, BookingViewModel>> Bookings { get; set; }
        public List<StorageViewModel> Storages { get; set; }
    }
}
