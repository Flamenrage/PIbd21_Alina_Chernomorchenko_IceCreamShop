using System;
using System.Collections.Generic;
using System.Text;
using IceCreamShopServiceImplement.Models;

namespace IceCreamShopServiceImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Ingredient> Ingredients { get; set; }

        public List<Booking> Bookings { get; set; }

        public List<IceCream> IceCreams { get; set; }

        public List<IceCreamIngredient> IceCreamIngredients { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageIngredient> StorageIngredients { get; set; }
        private DataListSingleton()
        {
            Ingredients = new List<Ingredient>();
            Bookings = new List<Booking>();
            IceCreams = new List<IceCream>();
            IceCreamIngredients = new List<IceCreamIngredient>();
            Storages = new List<Storage>();
            StorageIngredients = new List<StorageIngredient>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}