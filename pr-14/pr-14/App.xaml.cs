using System;
using System.IO;
using Xamarin.Forms;

namespace pr_14
{
    public partial class App : Application
    {
        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }
    }
}
