using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopDatabaseImplement.Implements;
using IceCreamShopServiceDAL.ServicesDal;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using IceCreamShopServiceDAL.HelperModels;
using System.Threading;
using System.Configuration;

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
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });

            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"]),
                Logic = container.Resolve<IMessageInfoLogic>()
            }, 0, 15000);
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
            currentContainer.RegisterType<IMessageInfoLogic, MessageInfoLogic>(
           new HierarchicalLifetimeManager());
            return currentContainer;
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
    }
}
