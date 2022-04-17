using System;
using System.Collections.Generic;
using CurrencyExchangeApp.Model;
using SQLite;
using Xamarin.Forms;

namespace CurrencyExchangeApp.View
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        void btnRegister_clicked(System.Object sender, System.EventArgs e)
        {
            if (emailEntry.Text == "" || firstNameEntry.Text == "" || lastNameEntry.Text == "" || passwordEntry.Text == "")
            {
                DisplayAlert("Failed", "The fields can not be empty", "Ok");

            }
            else
            {
                User user = new User()
                {
                    Email = emailEntry.Text,
                    FirstName = firstNameEntry.Text,
                    LastName = lastNameEntry.Text,
                    Password = passwordEntry.Text

                };


                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<User>();
                    var data = conn.Table<User>();
                    var row = data.Where(x => x.Email == emailEntry.Text);
                    if (row.Count() > 0)
                    {
                        DisplayAlert("Failed", "This email is already being used.", "Ok");
                    }
                    else
                    {
                        int another_row = conn.Insert(user);
                        if (another_row > 0)
                        {
                            DisplayAlert("Success", "Sign up was successful", "Ok");
                            emailEntry.Text = "";
                            firstNameEntry.Text = "";
                            lastNameEntry.Text = "";
                            passwordEntry.Text = "";
                            Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            DisplayAlert("Failed", "Sign up was not successful", "Ok");
                        }
                    }
                }
            }
            
        }
    }
}
