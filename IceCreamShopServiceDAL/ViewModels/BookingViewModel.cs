using IceCreamShopServiceDAL.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class BookingViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IceCreamId { get; set; }
        [DataMember]
        [DisplayName("Мороженое")]
        public string IceCreamName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DataMember]
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DataMember]
        [DisplayName("Статус")]
        public BookingStatus Status { get; set; }
        [DataMember]
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
        [DataMember]
        public int ClientId { set; get; }
        [DataMember]
        [DisplayName("Покупатель")]
        public string ClientFIO { set; get; }
        [DisplayName("Кондитер")]
        public string ImplementerFIO { set; get; }
        public int? ImplementorId { set; get; }
    }
}
