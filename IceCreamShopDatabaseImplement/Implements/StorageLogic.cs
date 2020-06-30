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
    public class StorageLogic : IStorageLogic
    {
        public List<StorageViewModel> GetList()
        {
            using (var context = new IceCreamShopDatabase())
            {
                return context.Storages
                .ToList()
               .Select(rec => new StorageViewModel
               {
                   Id = rec.Id,
                   StorageName = rec.StorageName,
                   StorageIngredients = context.StorageIngredients
                .Include(recSF => recSF.Ingredient)
               .Where(recSF => recSF.StorageId == rec.Id).
               Select(x => new StorageIngredientViewModel
               {
                   Id = x.Id,
                   StorageId = x.StorageId,
                   IngredientId = x.IngredientId,
                   IngredientName = context.Ingredients.FirstOrDefault(y => y.Id == x.IngredientId).IngredientName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }

        public StorageViewModel GetElement(int id)
        {
            using (var context = new IceCreamShopDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.Id == id);
                if (elem == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    return new StorageViewModel
                    {
                        Id = id,
                        StorageName = elem.StorageName,
                        StorageIngredients = context.StorageIngredients
                .Include(recSF => recSF.Ingredient)
               .Where(recSF => recSF.StorageId == elem.Id)
                        .Select(x => new StorageIngredientViewModel
                        {
                            Id = x.Id,
                            StorageId = x.StorageId,
                            IngredientId = x.IngredientId,
                            IngredientName = context.Ingredients.FirstOrDefault(y => y.Id == x.IngredientId)
                            .IngredientName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }

        public void AddElement(StorageBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var storage = new Storage();
                context.Storages.Add(storage);
                storage.StorageName = model.StorageName;
                context.SaveChanges();
            }
        }

        public void UpdElement(StorageBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                var elem = context.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Storages.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.StorageName = model.StorageName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void DelElement(StorageBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.StorageIngredients.RemoveRange(context.StorageIngredients.Where(rec => rec.StorageId == model.Id));
                        Storage element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element != null)
                        {
                            context.Storages.Remove(element);
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


        public void FillStorage(StorageIngredientBindingModel model)
        {
            using (var context = new IceCreamShopDatabase())
            {
                var item = context.StorageIngredients.FirstOrDefault(x => x.IngredientId == model.IngredientId
    && x.StorageId == model.StorageId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new StorageIngredient();
                    context.StorageIngredients.Add(elem);
                    elem.StorageId = model.StorageId;
                    elem.IngredientId = model.IngredientId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }

        public void RemoveFromStorage(BookingViewModel booking)
        {
            using (var context = new IceCreamShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var iceCreamIngredients = context.IceCreamIngredients
                            .Where(x => x.IceCreamId == booking.IceCreamId).ToList();
                        var storageIngredients = context.StorageIngredients.ToList();
                        foreach (var ingredient in iceCreamIngredients)
                        {
                            var count = ingredient.Count * booking.Count;
                            foreach (var si in storageIngredients)
                            {
                                if (si.IngredientId == ingredient.IngredientId && si.Count >= count)
                                {
                                    si.Count -= count;
                                    count = 0;
                                    context.SaveChanges();
                                    break;
                                }
                                else if (si.IngredientId == ingredient.IngredientId && si.Count < count)
                                {
                                    count -= si.Count;
                                    si.Count = 0;
                                    context.SaveChanges();
                                }
                            }
                            if (count > 0)
                                throw new Exception("Недостаточно компонентов на складе");
                        }
                        context.SaveChanges();
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
    }
}
