using IceCreamShopServiceDAL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    [DataContract]
    public class MessageInfoViewModel : BaseViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [Column(title: "Отправитель", width: 100)]
        [DataMember]
        public string SenderName { get; set; }
        [Column(title: "Дата письма", width: 100)]
        [DataMember]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Subject { get; set; }
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Body { get; set; }
        public override List<string> Properties() => new List<string> { 
            "SenderName", "DateDelivery", "Subject", "Body" };
    }    
}
