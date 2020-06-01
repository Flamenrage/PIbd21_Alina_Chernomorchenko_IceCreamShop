﻿using System;
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
        public List<Client> Clients { set; get; }

        private DataListSingleton()
        {
            Ingredients = new List<Ingredient>();
            Bookings = new List<Booking>();
            IceCreams = new List<IceCream>();
            IceCreamIngredients = new List<IceCreamIngredient>();
            Clients = new List<Client>();

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