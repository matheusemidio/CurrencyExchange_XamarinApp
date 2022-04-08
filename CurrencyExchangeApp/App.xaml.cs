using System;
using CurrencyExchangeApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyExchangeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CreateConversionPage());
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
