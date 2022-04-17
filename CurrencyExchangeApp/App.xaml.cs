using System;
using CurrencyExchangeApp.Model;
using CurrencyExchangeApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyExchangeApp
{
    public partial class App : Application
    {
        public static User loggedUser = new User();
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new ListConversionPage();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            DatabaseLocation = databaseLocation;
            MainPage = new NavigationPage(new LoginPage());

            //MainPage = new ListConversionPage();

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
