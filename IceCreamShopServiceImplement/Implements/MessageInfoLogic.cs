using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IceCreamShopServiceImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly DataListSingleton source;

        public MessageInfoLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            MessageInfo tempMessageInfo = new MessageInfo { MessageId = "" };

            foreach (var messageInfo in source.MessageInfoes)
            {
                if (model.MessageId == messageInfo.MessageId)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
            }

            source.MessageInfoes.Add(CreateModel(model, tempMessageInfo));
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();

            foreach (var messageInfo in source.MessageInfoes)
            {
                if (model != null)
                {
                    if (model.ClientId.HasValue && messageInfo.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(messageInfo));
                    }

                    continue;
                }

                result.Add(CreateViewModel(messageInfo));
            }

            return result;
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo MessageInfo)
        {
            int? clientId = null;

            foreach (var client in source.Clients)
            {
                if (model.ClientId.HasValue && model.ClientId == client.Id)
                {
                    clientId = model.ClientId;
                    break;
                }
            }

            MessageInfo.MessageId = model.MessageId;
            MessageInfo.ClientId = clientId;
            MessageInfo.SenderName = model.FromMailAddress;
            MessageInfo.DateDelivery = model.DateDelivery;
            MessageInfo.Subject = model.Subject;
            MessageInfo.Body = model.Body;

            return MessageInfo;
        }

        private MessageInfoViewModel CreateViewModel(MessageInfo MessageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = MessageInfo.MessageId,
                SenderName = MessageInfo.SenderName,
                DateDelivery = MessageInfo.DateDelivery,
                Subject = MessageInfo.Subject,
                Body = MessageInfo.Body
            };
        }
    }
}
