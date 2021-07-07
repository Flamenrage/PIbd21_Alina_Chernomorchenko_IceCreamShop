using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using IceCreamShopServiceDAL.Attributes;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class ClientViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ClientFIO { get; set; }
        [DataMember]
        [DisplayName("E-mail")]
        public string Login { get; set; }
        [DisplayName("Пароль")]
        [DataMember]
        public string Password { get; set; }
        public override List<string> Properties() => new List<string> { "Id", "ClientFIO" };
    }
}
