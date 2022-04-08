using System;
using System.Collections.Generic;
using CurrencyExchangeApp.View;
using Xamarin.Forms;

namespace CurrencyExchangeApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void btnRegister_clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }

        void btnLogin_clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}
