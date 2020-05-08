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
        private readonly IStorageLogic storageLogic;
        public ReportLogic(IIceCreamService iceCreamLogic,
            IBookingService bookingLogic, IStorageLogic storageLogic)
        {
            this.iceCreamLogic = iceCreamLogic;
            this.bookingLogic = bookingLogic;
            this.storageLogic = storageLogic;
        }
        public List<ReportIceCreamIngredientViewModel> GetIceCreamIngredient()
        {
            var icecreams= iceCreamLogic.Read(null);
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
        public List<ReportStorageIngredientViewModel> GetStorageIngredients()
        {
            var storages = storageLogic.GetList();
            var list = new List<ReportStorageIngredientViewModel>();
            foreach (var storage in storages)
            {
                foreach (var si in storage.StorageIngredients)
                {
                    var record = new ReportStorageIngredientViewModel
                    {
                        StorageName = storage.StorageName,
                        IngredientName = si.IngredientName,
                        Count = si.Count
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
        public void SaveStoragesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                IceCreams = null,
                Storages = storageLogic.GetList()
            });
        }
        public void SaveStorageIngredientToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов по складу",
                Bookings = null,
                Storages = storageLogic.GetList()
            });
        }
        public void SaveIceCreamsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список мороженого с ингредиентами",
                IceCreamIngredients = GetIceCreamIngredient()
            });
        }
        public void SaveIngredientsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список ингредиентов",
                IceCreamIngredients = null,
                StorageIngredients = GetStorageIngredients()
            });
        }
        public void SaveIceCreamIngredientToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Bookings = GetOrders(model)
            });
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
    }
}