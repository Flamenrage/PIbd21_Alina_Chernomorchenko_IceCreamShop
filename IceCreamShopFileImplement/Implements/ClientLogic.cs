using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopFileImplement.Models;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceCreamShopFileImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client element;
            if (model.Id.HasValue)
            {
                element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                element = new Client { Id = maxId + 1 };
                source.Clients.Add(element);
            }
            element.ClientFIO = model.ClientFIO;
            element.Login = model.Login;
            element.Password = model.Password;
        }

        public void Delete(ClientBindingModel model)
        {
            Client client = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (client != null)
            {
                source.Clients.Remove(client);
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            return source.Clients
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ClientViewModel
            {
                Id = rec.Id,
                ClientFIO = rec.ClientFIO,
                Login = rec.Login,
                Password = rec.Password
            })
            .ToList();
        }
    }
}
