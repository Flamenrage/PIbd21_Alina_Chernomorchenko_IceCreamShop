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
using System.Collections.Generic;
using IceCreamShopServiceDAL.Attributes;
using IceCreamShopServiceDAL.ViewModels;

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
            currentContainer.RegisterType<BackUpAbstractLogic, BackUpLogic>(
              new HierarchicalLifetimeManager());
            return currentContainer;
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
        public static void ConfigGrid<T>(List<T> data, DataGridView grid)
        {
            var type = typeof(T);
            if (type.BaseType == typeof(BaseViewModel))
            {
                // создаем объект от типа
                object obj = Activator.CreateInstance(type);
                // вытаскиваем метод получения списка заголовков
                var method = type.GetMethod("Properties");
                // вызываем метод
                var config = (List<string>)method.Invoke(obj, null);
                grid.Columns.Clear();
                foreach (var conf in config)
                {
                    // вытаскиваем нужное свойство из класса
                    var prop = type.GetProperty(conf);
                    if (prop != null)
                    {
                        // получаем список атрибутов
                        var attributes = prop.GetCustomAttributes(typeof(ColumnAttribute), true);
                        if (attributes != null && attributes.Length > 0)
                        {
                            foreach (var attr in attributes)
                            {
                                // ищем нужный нам атрибут
                                if (attr is ColumnAttribute columnAttr)
                                {
                                    var column = new DataGridViewTextBoxColumn
                                    {
                                        Name = conf,
                                        ReadOnly = true,
                                        HeaderText = columnAttr.Title,
                                        Visible = columnAttr.Visible,
                                        Width = columnAttr.Width
                                    };
                                    if (columnAttr.GridViewAutoSize != GridViewAutoSize.None)
                                    {
                                        column.AutoSizeMode = (DataGridViewAutoSizeColumnMode)Enum.
                                            Parse(typeof(DataGridViewAutoSizeColumnMode),
                                            columnAttr.GridViewAutoSize.ToString());
                                    }
                                    grid.Columns.Add(column);
                                }
                            }
                        }
                    }
                }
                // добавляем строки
                foreach (var elem in data)
                {
                    List<object> objs = new List<object>();
                    foreach (var conf in config)
                    {
                        var value = elem.GetType().GetProperty(conf).GetValue(elem);
                        objs.Add(value);
                    }
                    grid.Rows.Add(objs.ToArray());
                }
            }
        }
    }
}
