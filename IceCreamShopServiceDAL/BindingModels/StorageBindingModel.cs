using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IceCreamShopServiceDAL.BindingModels
{
    [DataContract]
    public class StorageBindingModel
    {
        [DataMember]
        public int? Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
        [DataMember]
        public List<StorageIngredientBindingModel> StorageIngredients { get; set; }
    }
}
