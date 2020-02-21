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
        public void CreateOrUpdate(IceCreamBindingModel model)
        {
            IceCream tempIceCream = model.Id.HasValue ? null : new IceCream { Id = 1 };
            foreach (var icecream in source.IceCreams)
            {
                if (icecream.IceCreamName == model.IceCreamName && icecream.Id != model.Id)
                {
                    throw new Exception("Уже есть сборка с таким названием");
                }
                if (!model.Id.HasValue && icecream.Id >= tempIceCream.Id)
                {
                    tempIceCream.Id = icecream.Id + 1;
                }
                else if (model.Id.HasValue && icecream.Id == model.Id)
                {
                    tempIceCream = icecream;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempIceCream == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempIceCream);
            }
            else
            {
                source.IceCreams.Add(CreateModel(model, tempIceCream));
            }
        }
        public void Delete(IceCreamBindingModel model)
        {
            // удаляем записи по деталям при удалении сборки
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].IceCreamId == model.Id)
                {
                    source.IceCreamIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.IceCreams.Count; ++i)
            {
                if (source.IceCreams[i].Id == model.Id)
                {
                    source.IceCreams.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private IceCream CreateModel(IceCreamBindingModel model, IceCream icecream)
        {
            icecream.IceCreamName = model.IceCreamName;
            icecream.Price = model.Price;
            //обновляем существующие детали и ищем максимальный идентификатор
            int maxIIId = 0;
            for (int i = 0; i < source.IceCreamIngredients.Count; ++i)
            {
                if (source.IceCreamIngredients[i].Id > maxIIId)
                {
                    maxIIId = source.IceCreamIngredients[i].Id;
                }
                if (source.IceCreamIngredients[i].IceCreamId == icecream.Id)
                {
                    // если в модели пришла запись детали с таким id
                    if (model.IceCreamIngredients.ContainsKey(source.IceCreamIngredients[i].IngredientId))
                    {
                        // обновляем количество
                        source.IceCreamIngredients[i].Count = model.IceCreamIngredients[source.IceCreamIngredients[i].IngredientId].Item2;
                        // из модели убираем эту запись, чтобы остались только не просмотренные
                        model.IceCreamIngredients.Remove(source.IceCreamIngredients[i].IngredientId);
                    }
                    else
                    {
                        source.IceCreamIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            foreach (var ad in model.IceCreamIngredients)
            {
                source.IceCreamIngredients.Add(new IceCreamIngredient
                {
                    Id = ++maxIIId,
                    IceCreamId = icecream.Id,
                    IngredientId = ad.Key,
                    Count = ad.Value.Item2
                });
            }
            return icecream;
        }
        public List<IceCreamViewModel> Read(IceCreamBindingModel model)
        {
            List<IceCreamViewModel> result = new List<IceCreamViewModel>();
            foreach (var icecream in source.IceCreams)
            {
                if (model != null)
                {
                    if (icecream.Id == model.Id)
                    {
                        result.Add(CreateViewModel(icecream));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(icecream));
            }
            return result;
        }
        private IceCreamViewModel CreateViewModel(IceCream icecream)
        {
            // требуется дополнительно получить список деталей для сборки с названиями и их количество
            Dictionary<int, (string, int)> iceCreamIngredients = new Dictionary<int,
            (string, int)>();
            foreach (var pc in source.IceCreamIngredients)
            {
                if (pc.IceCreamId == icecream.Id)
                {
                    string ingredientName = string.Empty;
                    foreach (var ingredient in source.Ingredients)
                    {
                        if (pc.IngredientId == ingredient.Id)
                        {
                            ingredientName = ingredient.IngredientName;
                            break;
                        }
                    }
                    iceCreamIngredients.Add(pc.IngredientId, (ingredientName, pc.Count));
                }
            }
            return new IceCreamViewModel
            {
                Id = icecream.Id,
                IceCreamName = icecream.IceCreamName,
                Price = icecream.Price,
                IceCreamIngredients = iceCreamIngredients
            };
        }
    }
}