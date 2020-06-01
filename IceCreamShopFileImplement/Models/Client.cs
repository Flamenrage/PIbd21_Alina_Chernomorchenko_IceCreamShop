using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopFileImplement.Models
{
    public class Client
    {
        public int Id { set; get; }
        public string ClientFIO { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
    }
}
