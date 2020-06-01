using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IceCreamShopRestApi.Models;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageLogic _storage;
        private readonly IIngredientService _ingredient;

        public StorageController(IStorageLogic storage, IIngredientService ingredient)
        {
            _storage = storage;
            _ingredient = ingredient;
        }

        [HttpGet]
        public List<StorageModel> GetStorages() => _storage.GetList()?.Select(rec => Convert(rec)).ToList();
        [HttpGet]
        public List<IngredientViewModel> GetIngredients() => _ingredient.Read(null)?.ToList();
        [HttpGet]
        public StorageModel GetStorage(int StorageId) => Convert(_storage.GetElement(StorageId));
        [HttpPost]
        public void CreateOrUpdateStorage(StorageBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _storage.UpdElement(model);
            }
            else
            {
                _storage.AddElement(model);
            }
        }
        [HttpPost]
        public void DeleteStorage(StorageBindingModel model) => _storage.DelElement(model);
        [HttpPost]
        public void FillStorage(StorageIngredientBindingModel model) => _storage.FillStorage(model);
        private StorageModel Convert(StorageViewModel model)
        {
            if (model == null) return null;
            return new StorageModel
            {
                Id = model.Id,
                StorageName = model.StorageName,
                StorageIngredients = model.StorageIngredients
            };
        }
    }
}