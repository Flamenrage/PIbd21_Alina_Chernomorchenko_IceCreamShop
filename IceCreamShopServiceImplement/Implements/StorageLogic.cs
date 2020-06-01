using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;

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
            throw new NotImplementedException();
        }

        public void RemoveFromStorage(int icecreamId, int icecreamsCount)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromStorage(BookingViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}