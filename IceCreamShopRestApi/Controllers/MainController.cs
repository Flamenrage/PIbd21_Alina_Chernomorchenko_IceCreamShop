using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ServicesDal;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopRestApi.Models;



namespace IceCreamShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IBookingService _order;
        private readonly IIceCreamService _icecream;
        private readonly MainService _main;
        public MainController(IBookingService order, IIceCreamService assembly, MainService main)
        {
            _order = order;
            _icecream = assembly;
            _main = main;
        }
        [HttpGet]
        public List<IceCream> GetIceCreams() => _icecream.Read(null)?.Select(rec =>
            Convert(rec)).ToList();
        [HttpGet]
        public IceCream GetIceCream(int icecreamId) => Convert(_icecream.Read(
            new IceCreamBindingModel { Id = icecreamId })?[0]);
        [HttpGet]
        public List<BookingViewModel> GetOrders(int clientId) => _order.Read(
            new BookingBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateBookingBindingModel model) =>
            _main.CreateBooking(model);
        private IceCream Convert(IceCreamViewModel model)
        {
            if (model == null)
                return null;
            return new IceCream
            {
                Id = model.Id,
                IceCreamName = model.IceCreamName,
                Price = model.Price
            };
        }
    }
}