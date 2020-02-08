using IceCreamShopServiceDAL.Enums;
using System;
using System.ComponentModel;

namespace IceCreamShopServiceDAL.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int IceCreamId { get; set; }
        [DisplayName("Мороженое")]
        public string IceCreamName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        public BookingStatus Status { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime? DateImplement { get; set; }
    }
}
