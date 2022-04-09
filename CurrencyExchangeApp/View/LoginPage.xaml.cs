using System;
using System.Collections.Generic;
using CurrencyExchangeApp.Model;
using CurrencyExchangeApp.View;
using SQLite;
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
            User user = new User()
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text

            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //conn.CreateTable<User>();

                var data = conn.Table<User>();
                var row = data.Where(x=> x.Email == emailEntry.Text && x.Password == passwordEntry.Text);
                //User aUser = conn.Find(user.Email);
                if (row != null)
                {
                    DisplayAlert("Success", "Login Success", "Ok");
                    emailEntry.Text = "";
                    passwordEntry.Text = "";

                    Navigation.PushAsync(new HomePage());
                }
                else
                {
                    DisplayAlert("Failed", "Email or Password invalid", "Ok");
                }
            }
        }
    }
}
