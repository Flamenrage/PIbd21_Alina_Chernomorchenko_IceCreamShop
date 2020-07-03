using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class ChangeStatusBindingModel
    {
        public int BookingId { get; set; }
        public int? ImplementerId { get; set; }
        public string ImplementerFIO { set; get; } 
    }
}
