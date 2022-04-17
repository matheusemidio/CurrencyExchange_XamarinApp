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
            if (emailEntry.Text == null || passwordEntry.Text == null)
            {
                DisplayAlert("Error", "Fields can not be empty", "Ok");


            }
            else
            {
                User user = new User()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text

                };
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    //conn.CreateTable<User>();

                    //matheus@me.com
                    //123

                    var data = conn.Table<User>();
                    List<User> listOfUsers = data.ToList();
                    bool isCorrectCredentials = false;
                    foreach (User aUser in listOfUsers)
                    {
                        if (aUser.Email == emailEntry.Text && aUser.Password == passwordEntry.Text)
                        {
                            isCorrectCredentials = true;
                            App.loggedUser = aUser;
                        }
                    }
                    //var row = data.Where(x => x.Email == emailEntry.Text && x.Password == passwordEntry.Text);
                    //if (row.Count() > 0)
                    Console.WriteLine(App.loggedUser.FirstName);
                    if(isCorrectCredentials == true)
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
}
