using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;


namespace IceCreamShopServiceImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;

        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempComponent = model.Id.HasValue ? null : new Client
            {
                Id = 1
            };
            foreach (var client in source.Clients)
            {
                if (client.ClientFIO == model.ClientFIO && client.Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
                if (!model.Id.HasValue && client.Id >= tempComponent.Id)
                {
                    tempComponent.Id = client.Id + 1;
                }
                else if (model.Id.HasValue && client.Id == model.Id)
                {
                    tempComponent = client;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempComponent == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempComponent);
            }
            else
            {
                source.Clients.Add(CreateModel(model, tempComponent));
            }
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (model.Id.HasValue && client.Id == model.Id)
                    {                        
                        result.Add(CreateViewModel(client));
                        break;                        
                    }
                    else if (client.Login == model.Login && client.Password == model.Password)
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO
            };
        }
    }
}
