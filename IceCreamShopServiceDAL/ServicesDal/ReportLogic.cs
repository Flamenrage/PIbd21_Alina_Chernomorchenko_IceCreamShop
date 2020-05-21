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
        private readonly IIceCreamService iceCreamLogic;
        private readonly IBookingService bookingLogic;
        public ReportLogic(IIceCreamService iceCreamLogic, IIngredientService ingredientLogic,
            IBookingService bookingLogic)
        {
            this.iceCreamLogic = iceCreamLogic;
            this.bookingLogic = bookingLogic;
        }
        public List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient()
        {
            var icecreams = iceCreamLogic.Read(null);
            var list = new List<ReportIceCreamIngredientViewModel>();
            foreach (var icecream in icecreams)
            {
                foreach (var ic in icecream.IceCreamIngredients)
                {
                    var record = new ReportIceCreamIngredientViewModel
                    {
                        IceCreamName = icecream.IceCreamName,
                        IngredientName = ic.Value.Item1,
                        Count = ic.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
       public List<IGrouping<DateTime, BookingViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = bookingLogic
           .Read(new BookingBindingModel
           {
               DateFrom = model.DateFrom,
               DateTo = model.DateTo
           })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();
            return list;
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