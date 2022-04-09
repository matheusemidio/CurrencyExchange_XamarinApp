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
        void btnUpdate_clicked(System.Object sender, System.EventArgs e)
        {

        }
    }
}
