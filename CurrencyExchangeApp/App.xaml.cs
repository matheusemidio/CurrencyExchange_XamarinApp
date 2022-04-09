using System;
using CurrencyExchangeApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyExchangeApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            MainPage = new NavigationPage(new LoginPage());

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
    }
}
