using Autofac;
using Autofac.Core;
using projectlufi.CollectionViews;
using projectlufi.Databases;
using projectlufi.Services;
using projectlufi.Views;
using projectlufi.Views.UrunSayfalari.UstGiyim;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectlufi
{
    public partial class App : Application
    {
        public static IContainer Container { get; set; }
        public static string FolderPath { get; private set; }
        private static ListItemDatabase database;
        public static ListItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ListItemDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ListDB.db"));
                }
                return database;

            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        
      
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ListItemDatabase>().As<IListService>().SingleInstance();



            Container = builder.Build();
        }

    }
}
