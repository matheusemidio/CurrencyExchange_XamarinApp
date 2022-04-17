using System;
using System.Collections.Generic;
using CurrencyExchangeApp.Model;
using SQLite;
using Xamarin.Forms;

namespace CurrencyExchangeApp.View
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            //User user = new User()
            //{
            //    Email = emailEntry.Text,
            //    Password = passwordEntry.Text

            //};
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    //conn.CreateTable<User>();

            //    var data = conn.Table<User>();
            //    var row = data.Where(x => x.Email == emailEntry.Text && x.Password == passwordEntry.Text);
            //    //User aUser = conn.Find(user.Email);
            //    //if (row != null)
            //    //{
            //    //    firstNameEntry.Text = dat

            //    //}
                
            //}

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            emailEntry.Text = App.loggedUser.Email;
            passwordEntry.Text = App.loggedUser.Password;
            firstNameEntry.Text = App.loggedUser.FirstName;
            lastNameEntry.Text = App.loggedUser.LastName;

        }
        void btnUpdate_clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                if (emailEntry.Text == "" || firstNameEntry.Text == "" || lastNameEntry.Text == "" || passwordEntry.Text == "")
                {
                    DisplayAlert("Failed", "The fields can not be empty", "Ok");

                }
                else
                {
                    App.loggedUser.Email = emailEntry.Text;
                    App.loggedUser.Password = passwordEntry.Text;
                    App.loggedUser.FirstName = firstNameEntry.Text;
                    App.loggedUser.LastName = lastNameEntry.Text;

                    int row = conn.Update(App.loggedUser);
                    if (row > 0)
                    {
                        DisplayAlert("Success", "Data was updated", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Failed", "Data was not updated", "Ok");
                    }
                }
                
            }
        }
    }
}
