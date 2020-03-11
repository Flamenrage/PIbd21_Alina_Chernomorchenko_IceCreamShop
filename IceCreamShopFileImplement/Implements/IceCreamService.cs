using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopFileImplement.Models;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace IceCreamShopFileImplement.Implements
{
    public class IceCreamService: IIceCreamService
    {
        private readonly FileDataListSingleton source;
        public IceCreamService()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(IceCreamBindingModel model)
        {
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.IceCreamName ==
           model.IceCreamName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть мороженое с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.IceCreams.Count > 0 ? source.Ingredients.Max(rec =>
               rec.Id) : 0;
                element = new IceCream { Id = maxId + 1 };
                source.IceCreams.Add(element);
            }
            element.IceCreamName = model.IceCreamName;
            element.Price = model.Price;
            source.IceCreamIngredients.RemoveAll(rec => rec.IceCreamId == model.Id &&
           !model.IceCreamIngredients.ContainsKey(rec.IngredientId));
            var updateIngredients = source.IceCreamIngredients.Where(rec => rec.IceCreamId ==
           model.Id && model.IceCreamIngredients.ContainsKey(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.Count =
               model.IceCreamIngredients[updateIngredient.IngredientId].Item2;
                model.IceCreamIngredients.Remove(updateIngredient.IngredientId);
            }
            int maxPCId = source.IceCreamIngredients.Count > 0 ?
           source.IceCreamIngredients.Max(rec => rec.Id) : 0;
            foreach (var pc in model.IceCreamIngredients)
            {
                source.IceCreamIngredients.Add(new IceCreamIngredient
                {
                    Id = ++maxPCId,
                    IceCreamId = element.Id,
                    IngredientId = pc.Key,
                    Count = pc.Value.Item2
                });
            }
        }
        public void Delete(IceCreamBindingModel model)
        {
            source.IceCreamIngredients.RemoveAll(rec => rec.IceCreamId == model.Id);
            IceCream element = source.IceCreams.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.IceCreams.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<IceCreamViewModel> Read(IceCreamBindingModel model)
        {
            return source.IceCreams
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new IceCreamViewModel
            {
                Id = rec.Id,
                IceCreamName = rec.IceCreamName,
                Price = rec.Price,
                IceCreamIngredients = source.IceCreamIngredients
            .Where(recPC => recPC.IceCreamId == rec.Id)
           .ToDictionary(recPC => recPC.IngredientId, recPC =>
            (source.Ingredients.FirstOrDefault(recC => recC.Id ==
           recPC.IngredientId)?.IngredientName, recPC.Count))
            })
            .ToList();
        }
    }
}