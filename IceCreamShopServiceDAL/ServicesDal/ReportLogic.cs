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
        private readonly IIngredientService IngredientLogic;
        private readonly IIceCreamService IceCreamLogic;
        private readonly IBookingService bookingLogic;
        public ReportLogic(IIceCreamService IceCreamLogic, IIngredientService IngredientLogic,
       IBookingService bookingLogic)
        {
            this.IceCreamLogic = IceCreamLogic;
            this.IngredientLogic = IngredientLogic;
            this.bookingLogic = bookingLogic;
        }

        public List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient()
        {
            var Ingredients = IngredientLogic.Read(null);
            var IceCreams = IceCreamLogic.Read(null);
            var list = new List<ReportIceCreamIngredientViewModel>();
            foreach (var Ingredient in Ingredients)
            {
                var record = new ReportIceCreamIngredientViewModel
                {
                    IngredientName = Ingredient.IngredientName,
                    IceCreams = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var IceCream in IceCreams)
                {
                    if (IceCream.IceCreamIngredients.ContainsKey(Ingredient.Id))
                    {
                        record.IceCreams.Add(new Tuple<string, int>(IceCream.IceCreamName,
                       IceCream.IceCreamIngredients[Ingredient.Id].Item2));
                        record.TotalCount +=
                       IceCream.IceCreamIngredients[Ingredient.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportBookingsViewModel> GetBookings(ReportBindingModel model)
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
        public void SaveIngredientsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов",
                Ingredients = IngredientLogic.Read(null)
            });
        }
        public void SaveIceCreamIngredientToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов",
                IceCreamIngredients = GetIceCreamIngredient()
            });
        }
        public void SaveBookingsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Bookings = GetBookings(model)
            });
        }
    }
}
