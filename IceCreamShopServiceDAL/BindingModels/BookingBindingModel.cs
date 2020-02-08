using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class BookingBindingModel
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
