using IceCreamShopServiceDAL.HelperModels;
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace IceCreamShopServiceDAL.ServicesDal
{
    public class ReportLogic
    {
        private readonly IIngredientService ingredientLogic;
        private readonly IIceCreamService iceCreamLogic;
        private readonly IBookingService bookingLogic;
        public ReportLogic(IIceCreamService iceCreamLogic, IIngredientService ingredientLogic,
            IBookingService bookingLogic)
        {
            this.iceCreamLogic = iceCreamLogic;
            this.ingredientLogic = ingredientLogic;
            this.bookingLogic = bookingLogic;
        }
        public List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient()
        {
            var ingredients = ingredientLogic.Read(null);
            var icecreams= iceCreamLogic.Read(null);
            var list = new List<ReportIceCreamIngredientViewModel>();
            foreach (var ingredient in ingredients)
            {
                foreach (var icecream in icecreams)
                {
                    if (icecream.IceCreamIngredients.ContainsKey(ingredient.Id))
                    {
                        var record = new ReportIceCreamIngredientViewModel
                        {
                            IceCreamName = icecream.IceCreamName,
                            IngredientName = ingredient.IngredientName,
                            Count = icecream.IceCreamIngredients[ingredient.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportBookingsViewModel> GetOrders(ReportBindingModel model)
        {
            return bookingLogic.Read(new BookingBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportBookingsViewModel
            {
                DateCreate = x.DateCreate,
                IceCreamName = x.IceCreamName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }
        public void SaveIceCreamsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список мороженого",
                IceCreams = iceCreamLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Bookings = GetOrders(model)
            });
        }

        [Obsolete]
        public void SaveIceCreamIngredientsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов мороженого",
                IceCreamIngredients = GetIceCreamIngredient()
            });
        }
    }
}