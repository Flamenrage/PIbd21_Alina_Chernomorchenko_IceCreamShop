using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IceCreamShopDatabaseImplement.Implements
{
    public class IceCreamService: IIceCreamService
    {
        public void CreateOrUpdate(IceCreamBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        IceCream element = context.IceCreams.FirstOrDefault(rec =>
                       rec.IceCreamName == model.IceCreamName && rec.Id != model.Id);
                        if (element != null)
                        {
                            throw new Exception("Уже есть мороженое с таким названием");
                        }
                        if (model.Id.HasValue)
                        {
                            element = context.IceCreams.FirstOrDefault(rec => rec.Id ==
                           model.Id);
                            if (element == null)
                            {
                                throw new Exception("Элемент не найден");
                            }
                        }
                        else
                        {
                            element = new IceCream();
                            context.IceCreams.Add(element);
                        }
                        element.IceCreamName = model.IceCreamName;
                        element.Price = model.Price;
                        context.SaveChanges();
                        if (model.Id.HasValue)
                        {
                            var IceCreamIngredients = context.IceCreamIngredients.Where(rec
                           => rec.IceCreamId == model.Id.Value).ToList();
                            // удалили те, которых нет в модели
                            context.IceCreamIngredients.RemoveRange(IceCreamIngredients.Where(rec =>
                            !model.IceCreamIngredients.ContainsKey(rec.IngredientId)).ToList());
                            context.SaveChanges();
                            // обновили количество у существующих записей
                            foreach (var updateIngredient in IceCreamIngredients)
                            {
                                updateIngredient.Count =
                               model.IceCreamIngredients[updateIngredient.IngredientId].Item2;

                                model.IceCreamIngredients.Remove(updateIngredient.IngredientId);
                            }
                            context.SaveChanges();
                        }
                        // добавили новые
                        foreach (var pc in model.IceCreamIngredients)
                        {
                            context.IceCreamIngredients.Add(new IceCreamIngredient
                            {
                                IceCreamId = element.Id,
                                IngredientId = pc.Key,
                                Count = pc.Value.Item2
                            });
                            context.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(IceCreamBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        // удаяем записи по продуктам при удалении закуски
                        context.IceCreamIngredients.RemoveRange(context.IceCreamIngredients.Where(rec =>
                        rec.IceCreamId == model.Id));
                        IceCream element = context.IceCreams.FirstOrDefault(rec => rec.Id
                        == model.Id);
                        if (element != null)
                        {
                            context.IceCreams.Remove(element);
                            context.SaveChanges();
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public List<IceCreamViewModel> Read(IceCreamBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                return context.IceCreams
                .Where(rec => model == null || rec.Id == model.Id)
                .ToList()
               .Select(rec => new IceCreamViewModel
               {
                   Id = rec.Id,
                   IceCreamName = rec.IceCreamName,
                   Price = rec.Price,
                   IceCreamIngredients = context.IceCreamIngredients
                .Include(recPC => recPC.Ingredient)
               .Where(recPC => recPC.IceCreamId == rec.Id)
               .ToDictionary(recPC => recPC.IngredientId, recPC =>
                (recPC.Ingredient?.IngredientName, recPC.Count))
               })
               .ToList();
            }
        }
    }
}