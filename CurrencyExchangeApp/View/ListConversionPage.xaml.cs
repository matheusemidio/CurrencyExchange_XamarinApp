using System;
using System.Collections.Generic;
using System.Transactions;
using SQLite;
using Xamarin.Forms;
using CurrencyExchangeApp.Model;

namespace CurrencyExchangeApp.View
{
    public partial class ListConversionPage : ContentPage
    {
        public ListConversionPage()
        {
            //User user = new User() {
            //    Id = 1,
            //    Email = "matheus@me.com",
            //    FirstName = "Matheus",
            //    LastName = "Cadena",
            //    Password = "123"
            //};
            //App.loggedUser = user;
            InitializeComponent();
        }
        public List<Operation> FillList() 
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Operation>();
                var data = conn.Table<Operation>();
                List<Operation> listOfOperations = data.ToList();

                List<Operation> filteredList = new List<Operation>();

                foreach (Operation aOperation in listOfOperations)
                {
                    if (aOperation.UserId == App.loggedUser.Id.ToString())
                    {
                        filteredList.Add(aOperation);
                    }

                }
                //if (filteredList.Count > 0)
                //{

                //    lvCurrencies.ItemsSource = filteredList;
                //}
                return filteredList;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
 
            
            lvCurrencies.ItemsSource = FillList();
        }

    }
}
