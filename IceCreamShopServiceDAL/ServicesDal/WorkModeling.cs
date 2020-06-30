using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Enums;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IceCreamShopServiceDAL.ServicesDal
{
    public class WorkModeling
    {
        private readonly IImplementerLogic implementerLogic;
        private readonly IBookingService bookingLogic;
        private readonly MainService mainLogic;
        private readonly Random rnd;

        public WorkModeling(IImplementerLogic implementerLogic, IBookingService orderLogic, MainService mainLogic)
        {
            this.implementerLogic = implementerLogic;
            this.bookingLogic = orderLogic;
            this.mainLogic = mainLogic;
            rnd = new Random(1000);
        }
        public void DoWork()
        {
            var implementers = implementerLogic.Read(null);
            var orders = bookingLogic.Read(new BookingBindingModel { FreeOrder = true });
            
                foreach (var implementer in implementers)
                {
                    WorkerWorkAsync(implementer, orders);
                }
        }
      

        private async void WorkerWorkAsync(ImplementerViewModel implementer, List<BookingViewModel> orders)
        {
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => bookingLogic.Read(new BookingBindingModel  
            {
                ImplementerId = implementer.Id
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                mainLogic.FinishBooking(new ChangeStatusBindingModel
                {
                    BookingId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            // потом заказы со статусом «Требуются материалы» (вдруг материалы подвезли)
            var isNotEnoughMaterialsBookings = bookingLogic.Read(new BookingBindingModel
            {
                IsNotEnoughMaterialsBookings = true
            });
            orders.RemoveAll(x => isNotEnoughMaterialsBookings.Contains(x));
            DoWork(implementer, isNotEnoughMaterialsBookings);
            await Task.Run(() =>
            {
                DoWork(implementer, orders);
            });
        }
        private void DoWork(ImplementerViewModel implementer, List<BookingViewModel> orders)
        {

            foreach (var order in orders)
            {
                // пытаемся назначить заказ на исполнителя
                try
                {
                    mainLogic.TakeBookingInWork(new ChangeStatusBindingModel
                    {
                        BookingId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    Boolean isNotEnoughMaterials = bookingLogic.Read(new BookingBindingModel
                    {
                        Id = order.Id
                    }).FirstOrDefault().Status == BookingStatus.Нехватка;
                    if (isNotEnoughMaterials)
                    {
                        continue;
                    }
                    // делаем работу
                    Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                    mainLogic.FinishBooking(new ChangeStatusBindingModel
                    {
                        BookingId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    // отдыхаем
                    Thread.Sleep(implementer.PauseTime);
                }
                catch (Exception) { }
            }
        }
    }
}
