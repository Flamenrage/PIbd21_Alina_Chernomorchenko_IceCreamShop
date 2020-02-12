using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;

namespace IceCreamShopServiceImplement.Implements
{
    public class IceCreamServiceList : IIceCreamService
    {
        private readonly DataListSingleton source;

        public IceCreamServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<IceCreamViewModel> GetList()
        {
            List<IceCreamViewModel> result = new List<IceCreamViewModel>();
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                // требуется дополнительно получить список ингредиентов для мороженого и их количество
                List<IceCreamIngredientViewModel> IceCreamIngredients = new
                List<IceCreamIngredientViewModel>();
                for (int j = 0; j < source.IceCreamIngredients.Count; ++j)
                {
                    if (source.IceCreamIngredients[j].IceCreamId == source.IceCreams[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.IceCreamIngredients[j].IngredientId ==
                            source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        IceCreamIngredients.Add(new IceCreamIngredientViewModel
                        {
                            Id = source.IceCreamIngredients[j].Id,
                            IceCreamId = source.IceCreamIngredients[j].IceCreamId,
                            IngredientId = source.IceCreamIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.IceCreamIngredients[j].Count
                        });
                    }
                }
                result.Add(new IceCreamViewModel
                {
                    Id = source.IceCreams[i].Id,
                    IceCreamName = source.IceCreams[i].IceCreamName,
                    Price = source.IceCreams[i].Price,
                    IceCreamIngredients = IceCreamIngredients
                });
            }
            return result;
        }

        public IceCreamViewModel GetElement(int id)
        {
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                // требуется дополнительно получить список ингредиентов для мороженого и их количество
                List<IceCreamIngredientViewModel> IceCreamIngredients = new
                List<IceCreamIngredientViewModel>();
                for (int j = 0; j < source.IceCreamIngredients.Count; ++j)
                {
                    if (source.IceCreamIngredients[j].IceCreamId == source.IceCreams[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.IceCreamIngredients[j].IngredientId ==
                            source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        IceCreamIngredients.Add(new IceCreamIngredientViewModel
                        {
                            Id = source.IceCreamIngredients[j].Id,
                            IceCreamId = source.IceCreamIngredients[j].IceCreamId,
                            IngredientId = source.IceCreamIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.IceCreamIngredients[j].Count
                        });
                    }
                }
                if (source.IceCreams[i].Id == id)
                {
                    return new IceCreamViewModel
                    {
                        Id = source.IceCreams[i].Id,
                        IceCreamName = source.IceCreams[i].IceCreamName,
                        Price = source.IceCreams[i].Price,
                        IceCreamIngredients = IceCreamIngredients
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(IceCreamBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                if (source.IceCreams[i].Id > maxId)
                {
                    maxId = source.IceCreams[i].Id;
                }
                if (source.IceCreams[i].IceCreamName == model.IceCreamName)
                {
                    throw new Exception("Уже есть мороженое с таким названием");
                }
            }
            source.IceCreams.Add(new IceCream
            {
                Id = maxId + 1,
                IceCreamName = model.IceCreamName,
                Price = model.Price
            });
            // ингредиенты для изделия
            int maxPCId = 0;
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.IceCreamIngredients[i].Id;
                }
            }
            // убираем дубли по ингредиентам
            for (int i = 0; i < model.IceCreamIngredients.Count; ++i)
            {
                for (int j = 1; j < model.IceCreamIngredients.Count; ++j)
                {
                    if (model.IceCreamIngredients[i].IngredientId ==
                    model.IceCreamIngredients[j].IngredientId)
                    {
                        model.IceCreamIngredients[i].Count +=
                        model.IceCreamIngredients[j].Count;
                        model.IceCreamIngredients.RemoveAt(j--);
                    }
                }
            }
            // добавляем ингредиенты
            for (int i = 0; i < model.IceCreamIngredients.Count; ++i)
            {
                source.IceCreamIngredients.Add(new IceCreamIngredient
                {
                    Id = ++maxPCId,
                    IceCreamId = maxId + 1,
                    IngredientId = model.IceCreamIngredients[i].IngredientId,
                    Count = model.IceCreamIngredients[i].Count
                });
            }
        }

        public void UpdElement(IceCreamBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                if (source.IceCreams[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.IceCreams[i].IceCreamName == model.IceCreamName &&
                source.IceCreams[i].Id != model.Id)
                {
                    throw new Exception("Уже есть мороженое с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.IceCreams[index].IceCreamName = model.IceCreamName;
            source.IceCreams[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.IceCreamIngredients[i].Id;
                }
            }
            // обновляем существуюущие ингредиенты
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].IceCreamId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.IceCreamIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.IceCreamIngredients[i].Id ==
                        model.IceCreamIngredients[j].Id)
                        {
                            source.IceCreamIngredients[i].Count =
                            model.IceCreamIngredients[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.IceCreamIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.IceCreamIngredients.Count; ++i)
            {
                if (model.IceCreamIngredients[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.IceCreamIngredients.Count; ++j)
                    {
                        if (source.IceCreamIngredients[j].IceCreamId == model.Id &&
                        source.IceCreamIngredients[j].IngredientId ==
                        model.IceCreamIngredients[i].IngredientId)
                        {
                            source.IceCreamIngredients[j].Count +=
                            model.IceCreamIngredients[i].Count;
                            model.IceCreamIngredients[i].Id =
                            source.IceCreamIngredients[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.IceCreamIngredients[i].Id == 0)
                    {
                        source.IceCreamIngredients.Add(new IceCreamIngredient
                        {
                            Id = ++maxPCId,
                            IceCreamId = model.Id,
                            IngredientId = model.IceCreamIngredients[i].IngredientId,
                            Count = model.IceCreamIngredients[i].Count
                        });
                    }
                }
            }
        }
        public void DelElement(int id)
        {
            // удаяем записи по ингредиентам при удалении изделия
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].IceCreamId == id)
                {
                    source.IceCreamIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                if (source.IceCreams[i].Id == id)
                {
                    source.IceCreams.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}