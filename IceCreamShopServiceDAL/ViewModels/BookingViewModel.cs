using IceCreamShopServiceDAL.Attributes;
using IceCreamShopServiceDAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class BookingViewModel : BaseViewModel
    {
        [DataMember]
        public int IceCreamId { get; set; }
        [DataMember]
        [Column(title: "Название мороженого", gridViewAutoSize: GridViewAutoSize.DisplayedCells)]
        public string IceCreamName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public BookingStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        [Column(title: "Покупатель", width: 150)]
        public string ClientFIO { set; get; }
        [Column(title: "Кондитер", width: 150)]
        public string ImplementerFIO { set; get; }
        public int? ImplementorId { set; get; }
        public override List<string> Properties() => new List<string> { "Id",
            "IceCreamId", "IceCreamName", "Count", "Sum", "Status", "DateCreate", "DateImplement", "ClientFIO" };
    }
}
