using IceCreamShopServiceDAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace IceCreamShopDatabaseImplement.Models
{
    public class Booking
    {
        [Required]
        public int ClientId { set; get; }
        [Required]
        public string ClientFIO { set; get; }
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual IceCream IceCream { get; set; }
    }
}
