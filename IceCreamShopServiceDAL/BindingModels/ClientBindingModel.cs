using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace IceCreamShopServiceDAL.BindingModels
{
    public class ClientBindingModel
    {
        [DataMember]
        public int? Id { set; get; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        public string Login { set; get; }
        [DataMember]
        public string Password { set; get; }
    }
}
