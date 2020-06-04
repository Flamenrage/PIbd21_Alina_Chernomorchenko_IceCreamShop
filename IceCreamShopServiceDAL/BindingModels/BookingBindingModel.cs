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
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ClientId { set; get; }
        public string ClientFIO { set; get; }
        public string ImplementerFIO { set; get; }
        public int? ImplementerId { set; get; }
        public bool? FreeOrder { set; get; }
        public bool? IsNotEnoughMaterialsBookings { get; set; }
    }
}
