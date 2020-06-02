using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;
using System.Linq;

namespace IceCreamShopServiceImplement.Implements
{
    public class StorageLogic : IStorageLogic
    {
        private readonly DataListSingleton source;
        public StorageLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            List<StorageViewModel> result = new List<StorageViewModel>();
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageIngredientViewModel> StorageIngredients = new
                List<StorageIngredientViewModel>();
                for (int j = 0; j < source.StorageIngredients.Count; ++j)
                {
                    if (source.StorageIngredients[j].StorageId == source.Storages[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.StorageIngredients[j].IngredientId ==
                           source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        StorageIngredients.Add(new StorageIngredientViewModel
                        {
                            Id = source.StorageIngredients[j].Id,
                            StorageId = source.StorageIngredients[j].StorageId,
                            IngredientId = source.StorageIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.StorageIngredients[j].Count
                        });
                    }
                }
                result.Add(new StorageViewModel
                {
                    Id = source.Storages[i].Id,
                    StorageName = source.Storages[i].StorageName,
                    StorageIngredients = StorageIngredients
                });
            }
            return result;
        }
        public StorageViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                List<StorageIngredientViewModel> StorageIngredients = new
                List<StorageIngredientViewModel>();
                for (int j = 0; j < source.StorageIngredients.Count; ++j)
                {
                    if (source.StorageIngredients[j].StorageId == source.Storages[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.StorageIngredients[j].IngredientId ==
                           source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        StorageIngredients.Add(new StorageIngredientViewModel
                        {
                            Id = source.StorageIngredients[j].Id,
                            StorageId = source.StorageIngredients[j].StorageId,
                            IngredientId = source.StorageIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.StorageIngredients[j].Count
                        });
                    }
                }
                if (source.Storages[i].Id == id)
                {
                    return new StorageViewModel
                    {
                        Id = source.Storages[i].Id,
                        StorageName = source.Storages[i].StorageName,
                        StorageIngredients = StorageIngredients
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id > maxId)
                {
                    maxId = source.Storages[i].Id;
                }
                if (source.Storages[i].StorageName == model.StorageName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Storages[i].StorageName == model.StorageName &&
                source.Storages[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Storages[index].StorageName = model.StorageName;

        }
        public void DelElement(StorageBindingModel model)
        {
            for (int i = 0; i < source.StorageIngredients.Count; ++i)
            {
                if (source.StorageIngredients[i].StorageId == model.Id)
                {
                    source.StorageIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Storages.Count; ++i)
            {
                if (source.Storages[i].Id == model.Id)
                {
                    source.Storages.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void FillStorage(StorageIngredientBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.StorageIngredients.Count; ++i)
            {
                if (source.StorageIngredients[i].IngredientId == model.IngredientId
                    && source.StorageIngredients[i].StorageId == model.StorageId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.StorageIngredients[foundItemIndex].Count =
                    source.StorageIngredients[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.StorageIngredients.Count; ++i)
                {
                    if (source.StorageIngredients[i].Id > maxId)
                    {
                        maxId = source.StorageIngredients[i].Id;
                    }
                }
                source.StorageIngredients.Add(new StorageIngredient
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }
        public bool CheckIngredientsAvailability(int icecreamId, int icecreamsCount)
        {
            var iceCreamIngredients = source.IceCreamIngredients.Where(x => x.IceCreamId == icecreamId);
            if (iceCreamIngredients.Count() == 0) return false;
            foreach (var elem in iceCreamIngredients)
            {
                int count = 0;
                count = source.StorageIngredients.FindAll(x => x.IngredientId == elem.IngredientId).Sum(x => x.Count);
                if (count < elem.Count * icecreamsCount)
                    return false;
            }
            return true;
        }

        public void RemoveFromStorage(BookingViewModel model)
        {
            var icecreamIngredients = source.IceCreamIngredients.Where(rec => rec.Id == model.IceCreamId).ToList();
            foreach (var pc in icecreamIngredients)
            {
                var storageIngredients = source.StorageIngredients.Where(rec => rec.IngredientId == pc.IngredientId);
                int sum = storageIngredients.Sum(rec => rec.Count);
                if (sum < pc.Count * model.Count)
                {
                    throw new Exception("Недостаточно ингредиентов на складе");
                }
                else
                {
                    int left = pc.Count * model.Count;
                    foreach (var si in storageIngredients)
                    {
                        if (si.Count >= left)
                        {
                            si.Count -= left;
                            break;
                        }
                        else
                        {
                            left -= si.Count;
                            si.Count = 0;
                        }
                    }
                }
            }
        }
    }
}