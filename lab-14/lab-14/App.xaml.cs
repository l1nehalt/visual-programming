using lab_14.Services;
using System;
using System.IO;
using Xamarin.Forms;

namespace lab_14
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "supply.db";
        private static DatabaseService _database;

        public static DatabaseService Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DatabaseService(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                            DATABASE_NAME));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
    }
}