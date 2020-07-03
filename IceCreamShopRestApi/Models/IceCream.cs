using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamShopRestApi.Models
{
    public class IceCream
    {
        public int Id { set; get; }
        public string IceCreamName { set; get; }
        public decimal Price { set; get; }
    }
}
