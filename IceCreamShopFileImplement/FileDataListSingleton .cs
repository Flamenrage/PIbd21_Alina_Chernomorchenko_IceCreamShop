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
        private readonly string ClientFileName = "Client.xml";
        private readonly string ImplementerFileName = "Implementer.xml";
        private readonly string MessageInfoFileName = "MessageInfo.xml";



        public List<Ingredient> Ingredients { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<IceCream> IceCreams { get; set; }
        public List<IceCreamIngredient> IceCreamIngredients { get; set; }
        public List<Client> Clients { set; get; }
        public List<Implementer> Implementers { set; get; }
        public List<MessageInfo> MessageInfoes { get; set; }

        private FileDataListSingleton()
        {
            Ingredients = LoadIngredients();
            Bookings = LoadBookings();
            IceCreams = LoadIceCreams();
            IceCreamIngredients = LoadIceCreamIngredients();
            Clients = LoadClients();
            Implementers = LoadImplementers();
            MessageInfoes = LoadMessageInfoes();
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
            SaveClients();
            SaveImplementers();
            SaveMessageInfoes();
        }
        private List<MessageInfo> LoadMessageInfoes()
        {
            var list = new List<MessageInfo>();
            if (File.Exists(MessageInfoFileName))
            {
                XDocument xDocument = XDocument.Load(MessageInfoFileName);
                var xElements = xDocument.Root.Elements("MessageInfo").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new MessageInfo
                    {
                        MessageId = elem.Attribute("MessageId").Value,
                        ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
                        SenderName = elem.Element("SenderName").Value,
                        DateDelivery = Convert.ToDateTime(elem.Element("DateDelivery").Value),
                        Subject = elem.Element("Subject").Value,
                        Body = elem.Element("Body").Value
                    });
                }
            }
            return list;
        }
        private void SaveMessageInfoes()
        {
            if (MessageInfoes != null)
            {
                var xElement = new XElement("MessageInfoes");
                foreach (var messageInfo in MessageInfoes)
                {
                    xElement.Add(new XElement("MessageInfo",
                    new XAttribute("Id", messageInfo.MessageId),
                    new XElement("ClientId", messageInfo.ClientId),
                    new XElement("SenderName", messageInfo.SenderName),
                    new XElement("DateDelivery", messageInfo.DateDelivery),
                    new XElement("Subject", messageInfo.Subject),
                    new XElement("Body", messageInfo.Body)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(MessageInfoFileName);
            }
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ClientFIO = elem.Element("ClientFIO").Value,
                        Login = elem.Element("Login").Value,
                        Password = elem.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private List<Implementer> LoadImplementers()
        {
            var list = new List<Implementer>();
            if (File.Exists(ImplementerFileName))
            {
                XDocument xDocument = XDocument.Load(ImplementerFileName);
                var xElements = xDocument.Root.Elements("Implementor").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Implementer
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ImplementerFIO = elem.Element("ImplementerFIO").Value
                    });
                }
            }
            return list;
        }

        private void SaveImplementers()
        {
            if (Implementers != null)
            {
                var xElement = new XElement("Implementers");
                foreach (var implementer in Implementers)
                {
                    xElement.Add(new XElement("Implementer",
                    new XAttribute("Id", implementer.Id),
                    new XElement("ImplementerFIO", implementer.ImplementerFIO)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ImplementerFileName);
            }
        }

        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("ClientFIO", client.ClientFIO),
                    new XElement("Login", client.Login),
                    new XElement("Password", client.Password)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
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
