using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.Serialization;
using IceCreamShopServiceDAL.Attributes;

namespace IceCreamShopServiceDAL.ViewModels
{
    [DataContract]
    public class IceCreamViewModel : BaseViewModel
    {
        [DataMember]
        [Column(title: "Название мороженого", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string IceCreamName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> IceCreamIngredients { get; set; }
        public override List<string> Properties() => new List<string> {
            "Id", "IceCreamName", "Price" };
    }
}
