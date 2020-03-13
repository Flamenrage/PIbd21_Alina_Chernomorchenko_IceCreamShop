using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplement.Implements;
using IceCreamShopServiceDAL.ServicesDal;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace IceCreamShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IIceCreamService, IceCreamServiceList>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBookingService, BookingServiceList>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageLogic, StorageLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainService>(
                new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
