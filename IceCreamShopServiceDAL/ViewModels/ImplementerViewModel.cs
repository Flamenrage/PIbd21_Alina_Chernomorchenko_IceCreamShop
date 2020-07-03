using IceCreamShopServiceDAL.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class ImplementerViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        [DataMember]
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
        public override List<string> Properties() => new List<string> {
            "Id", "ImplementerFIO", "WorkingTime", "PauseTime" };
    }
}

