using System;
using System.Collections.Generic;
using System.Text;
using IceCreamShopServiceDAL.Enums;

namespace IceCreamShopServiceDAL.ViewModels
{
   public class ReportBookingsViewModel
    {
        public DateTime DateCreate { get; set; }
        public string IceCreamName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public BookingStatus Status { get; set; }
    }
}
