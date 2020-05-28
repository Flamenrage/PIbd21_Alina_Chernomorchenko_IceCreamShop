using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceDAL.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<IceCreamViewModel> IceCreams{ get; set; }
        public List<StorageViewModel> Storages { get; set; }
    }
}
