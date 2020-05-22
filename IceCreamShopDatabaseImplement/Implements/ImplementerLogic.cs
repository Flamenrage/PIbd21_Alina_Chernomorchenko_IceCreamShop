using IceCreamShopDatabaseImplement.Models;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                Implementer implementer = context.Implementers.FirstOrDefault(rec =>
               rec.ImplementerFIO == model.ImplementerFIO && rec.Id != model.Id);
                if (implementer != null)
                {
                    throw new Exception("Уже есть такой рабочий");
                }
                if (model.Id.HasValue)
                {
                    implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (implementer == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    implementer = new Implementer();
                    context.Implementers.Add(implementer);
                }
                implementer.ImplementerFIO = model.ImplementerFIO;
                implementer.WorkTime = model.WorkingTime;
                implementer.PauseTime = model.PauseTime;
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                Implementer implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (implementer != null)
                {
                    context.Implementers.Remove(implementer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                return context.Implementers
                .Where(rec => model == null || rec.Id == model.Id)
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }
    }
}
