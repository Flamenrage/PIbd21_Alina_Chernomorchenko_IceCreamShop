using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace IceCreamShopDatabaseImplement.Models
{
    public class IceCream
    {
        public int Id { get; set; }
        [Required]
        public string IceCreamName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<IceCreamIngredient> IceCreamIngredients { get; set; }
        [ForeignKey("IceCreamId")]
        public virtual List<Booking> Bookings { get; set; }
    }
}
