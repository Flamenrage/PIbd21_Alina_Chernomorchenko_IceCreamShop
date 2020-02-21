using System;
using IceCreamShopServiceDAL.Enums;

namespace IceCreamShopServiceDAL.BindingModels
{
    public class BookingBindingModel
    {
        public int? Id { get; set; }
        public int IceCreamId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
