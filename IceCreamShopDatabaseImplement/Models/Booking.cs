using IceCreamShopServiceDAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace IceCreamShopDatabaseImplement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Required]
        public int ClientId { set; get; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public BookingStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public int IceCreamId { get; set; }
        public virtual Client Client { get; set; }
        public virtual IceCream IceCream { get; set; }
        public int? ImplementerId { get; set; }
        public Implementer Implementer { get; set; }
    }
}
