﻿using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopDatabaseImplement.Implements;
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
            currentContainer.RegisterType<IIceCreamService, IceCreamService>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientService>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBookingService, BookingService>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainService>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic,
                ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkModeling>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
