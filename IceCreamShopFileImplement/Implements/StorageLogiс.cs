using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopFileImplement.Models;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace IceCreamShopFileImplement.Implements
{
    public class StorageLogiс : IStorageLogic
    {
        private readonly FileDataListSingleton source;
        public StorageLogiс()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorageViewModel> GetList()
        {
            return source.Storages.Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageIngredients = source.StorageIngredients.Where(z => z.StorageId == rec.Id).Select(x => new StorageIngredientViewModel
                {
                    Id = x.Id,
                    StorageId = x.StorageId,
                    IngredientId = x.IngredientId,
                    IngredientName = source.Ingredients.FirstOrDefault(y => y.Id == x.IngredientId)?.IngredientName,
                    Count = x.Count
                }).ToList()
            })
                .ToList();
        }
        public StorageViewModel GetElement(int id)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == id);
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
                    StorageIngredients = source.StorageIngredients.Where(z => z.StorageId == elem.Id).Select(x => new StorageIngredientViewModel
                    {
                        Id = x.Id,
                        StorageId = x.StorageId,
                        IngredientId = x.IngredientId,
                        IngredientName = source.Ingredients.FirstOrDefault(y => y.Id == x.IngredientId)?.IngredientName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }

        public void AddElement(StorageBindingModel model)
        {

            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Storages.Count > 0 ? source.Storages.Max(rec => rec.Id) : 0;
            source.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdElement(StorageBindingModel model)
        {
            var elem = source.Storages.FirstOrDefault(x => x.StorageName == model.StorageName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Storages.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.StorageName = model.StorageName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(StorageBindingModel model)
        {
            var elem = source.Storages.FirstOrDefault(x => x.Id == model.Id);
            if (elem != null)
            {
                source.Storages.Remove(elem);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public void FillStorage(StorageIngredientBindingModel model)
        {
            var item = source.StorageIngredients.FirstOrDefault(x => x.IngredientId == model.IngredientId
                    && x.StorageId == model.StorageId);

            if (item != null)
            {
                item.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageIngredients.Count > 0 ? source.StorageIngredients.Max(rec => rec.Id) : 0;
                source.StorageIngredients.Add(new StorageIngredient
                {
                    Id = maxId + 1,
                    StorageId = model.StorageId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }

        public bool CheckIngredientsAvailability(int icecreamId, int icecreamCount)
        {
            var IceCreamIngredients = source.IceCreamIngredients.Where(x => x.IceCreamId == icecreamId);
            if (IceCreamIngredients.Count() == 0) return false;
            foreach (var elem in IceCreamIngredients)
            {
                int count = source.StorageIngredients.FindAll(x => x.IngredientId == elem.IngredientId).Sum(rec => rec.Count);
                if (count < elem.Count * icecreamCount) return false;
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
