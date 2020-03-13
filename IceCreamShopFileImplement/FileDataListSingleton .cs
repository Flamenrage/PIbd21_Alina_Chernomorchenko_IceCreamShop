using System;
using IceCreamShopServiceDAL.Enums;
using IceCreamShopFileImplement.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace IceCreamShopFileImplement
{
    class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string IngredientFileName = "Ingredient.xml";
        private readonly string BookingFileName = "Booking.xml";
        private readonly string IceCreamFileName = "IceCream.xml";
        private readonly string IceCreamIngredientFileName = "IceCreamIngredient.xml";
        public List<Ingredient> Ingredients { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<IceCream> IceCreams { get; set; }
        public List<IceCreamIngredient> IceCreamIngredients { get; set; }
        private FileDataListSingleton()
        {
            Ingredients = LoadIngredients();
            Bookings = LoadBookings();
            IceCreams = LoadIceCreams();
            IceCreamIngredients = LoadIceCreamIngredients();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveIngredients();
            SaveBookings();
            SaveIceCreams();
            SaveIceCreamIngredients();
        }
        private List<Ingredient> LoadIngredients()
        {
            var list = new List<Ingredient>();
            if (File.Exists(IngredientFileName))
            {
                XDocument xDocument = XDocument.Load(IngredientFileName);
                var xElements = xDocument.Root.Elements("Ingredient").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Ingredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IngredientName = elem.Element("IngredientName").Value
                    });
                }
            }
            return list;
        }
        private List<Booking> LoadBookings()
        {
            var list = new List<Booking>();
            if (File.Exists(BookingFileName))
            {
                XDocument xDocument = XDocument.Load(BookingFileName);
                var xElements = xDocument.Root.Elements("Booking").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Booking
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IceCreamId = Convert.ToInt32(elem.Element("IceCreamId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (BookingStatus)Enum.Parse(typeof(BookingStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<IceCream> LoadIceCreams()
        {
            var list = new List<IceCream>();
            if (File.Exists(IceCreamFileName))
            {
                XDocument xDocument = XDocument.Load(IceCreamFileName);
                var xElements = xDocument.Root.Elements("IceCream").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new IceCream
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IceCreamName = elem.Element("IceCreamName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<IceCreamIngredient> LoadIceCreamIngredients()
        {
            var list = new List<IceCreamIngredient>();
            if (File.Exists(IceCreamIngredientFileName))
            {
                XDocument xDocument = XDocument.Load(IceCreamIngredientFileName);
                var xElements = xDocument.Root.Elements("IceCreamIngredient").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new IceCreamIngredient
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        IceCreamId = Convert.ToInt32(elem.Element("IceCreamId").Value),
                        IngredientId = Convert.ToInt32(elem.Element("IngredientId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private void SaveIngredients()
        {
            if (Ingredients != null)
            {
                var xElement = new XElement("Ingredients");
                foreach (var ingredient in Ingredients)
                {
                    xElement.Add(new XElement("Ingredient",
                    new XAttribute("Id", ingredient.Id),
                    new XElement("IngredientName", ingredient.IngredientName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IngredientFileName);
            }
        }
        private void SaveBookings()
        {
            if (Bookings != null)
            {
                var xElement = new XElement("Bookings");
                foreach (var booking in Bookings)
                {
                    xElement.Add(new XElement("Booking",
                    new XAttribute("Id", booking.Id),
                    new XElement("IceCreamId", booking.IceCreamId),
                    new XElement("Count", booking.Count),
                    new XElement("Sum", booking.Sum),
                    new XElement("Status", booking.Status),
                    new XElement("DateCreate", booking.DateCreate),
                    new XElement("DateImplement", booking.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(BookingFileName);
            }
        }
        private void SaveIceCreams()
        {
            if (IceCreams != null)
            {
                var xElement = new XElement("IceCreams");
                foreach (var icecream in IceCreams)
                {
                    xElement.Add(new XElement("IceCream",
                    new XAttribute("Id", icecream.Id),
                    new XElement("IceCreamName", icecream.IceCreamName),
                    new XElement("Price", icecream.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IceCreamFileName);
            }
        }
        private void SaveIceCreamIngredients()
        {
            if (IceCreamIngredients != null)
            {
                var xElement = new XElement("IceCreamIngredients");
                foreach (var icecreamIngredient in IceCreamIngredients)
                {
                    xElement.Add(new XElement("IceCreamIngredient",
                    new XAttribute("Id", icecreamIngredient.Id),
                    new XElement("IceCreamId", icecreamIngredient.IceCreamId),
                    new XElement("IngredientId", icecreamIngredient.IngredientId),
                    new XElement("Count", icecreamIngredient.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(IceCreamIngredientFileName);
            }
        }
    }
}
