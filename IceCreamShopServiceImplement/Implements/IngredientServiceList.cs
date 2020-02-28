using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using IceCreamShopServiceImplement.Models;

namespace IceCreamShopServiceImplement.Implements
{
    public class IngredientServiceList : IIngredientService
    {
            private readonly DataListSingleton source;

            public IngredientServiceList()
            {
                source = DataListSingleton.GetInstance();
            }

            public void CreateOrUpdate(IngredientBindingModel model)
            {
                Ingredient tempIngredient = model.Id.HasValue ? null : new Ingredient
                {
                    Id = 1
                };
                foreach (var ingredient in source.Ingredients)
                {
                    if (ingredient.IngredientName == model.IngredientName && ingredient.Id !=
                   model.Id)
                    {
                        throw new Exception("Уже есть компонент с таким названием");
                    }
                    if (!model.Id.HasValue && ingredient.Id >= tempIngredient.Id)
                    {
                        tempIngredient.Id = ingredient.Id + 1;
                    }
                    else if (model.Id.HasValue && ingredient.Id == model.Id)      
                    {
                        tempIngredient = ingredient;
                    }
                }
                if (model.Id.HasValue)
                {
                    if (tempIngredient == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    CreateModel(model, tempIngredient);
                }
                else
                {
                    source.Ingredients.Add(CreateModel(model, tempIngredient));
                }
            }
            public void Delete(IngredientBindingModel model)
            {
                for (int i = 0; i < source.Ingredients.Count; ++i)
                {
                    if (source.Ingredients[i].Id == model.Id.Value)
                    {
                        source.Ingredients.RemoveAt(i);
                        return;
                    }
                }
                throw new Exception("Элемент не найден");
            }
            public List<IngredientViewModel> Read(IngredientBindingModel model)
            {
                List<IngredientViewModel> result = new List<IngredientViewModel>();
                foreach (var ingredient in source.Ingredients)
                {
                    if (model != null)
                    {
                        if (ingredient.Id == model.Id)
                        {
                            result.Add(CreateViewModel(ingredient));
                            break;
                        }
                        continue;
                    }
                    result.Add(CreateViewModel(ingredient));
                }
                return result;
            }
            private Ingredient CreateModel(IngredientBindingModel model, Ingredient ingredient)
            {
                ingredient.IngredientName = model.IngredientName;
                return ingredient;
            }
            private IngredientViewModel CreateViewModel(Ingredient ingredient)
            {
                return new IngredientViewModel
                {
                     Id = ingredient.Id,
                     IngredientName = ingredient.IngredientName
                };
            }
         }
    }