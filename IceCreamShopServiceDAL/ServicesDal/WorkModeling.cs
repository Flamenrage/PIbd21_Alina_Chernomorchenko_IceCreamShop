using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
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
            await Task.Run(() =>
            {
                foreach (var order in orders)
                {
                    // пытаемся назначить заказ на исполнителя
                    try
                    {
                        mainLogic.TakeBookingInWork(new ChangeStatusBindingModel
                        {
                            BookingId = order.Id,
                            ImplementerId = implementer.Id,
                            ImplementerFIO = implementer.ImplementerFIO
                        });
                        // делаем работу
                        Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                        mainLogic.FinishBooking(new ChangeStatusBindingModel
                        {
                            BookingId = order.Id
                        });
                        // отдыхаем
                        Thread.Sleep(implementer.PauseTime);
                    }
                    catch (Exception) { }
                }
            });
        }
    }
}
