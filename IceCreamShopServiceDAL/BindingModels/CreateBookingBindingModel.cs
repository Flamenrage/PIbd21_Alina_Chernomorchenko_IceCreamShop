using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class CreateBookingBindingModel
    {
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        public string ClientFIO { set; get; }
        [DataMember]
        public int IceCreamId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
