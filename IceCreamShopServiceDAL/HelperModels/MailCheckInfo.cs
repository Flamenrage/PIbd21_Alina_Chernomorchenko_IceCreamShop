using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoLogic Logic { get; set; }
    }
}
