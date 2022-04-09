using System;
using System.Collections.Generic;
using System.Net.Http;
using CurrencyExchangeApp.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CurrencyExchangeApp.View
{
    public partial class CreateConversionPage : ContentPage
    {
        public CreateConversionPage()
        {
            InitializeComponent();
            GetCurrencies();
        }

        private async void GetCurrencies()
        {
            string url = "https://v6.exchangerate-api.com/v6/3808ca223ddc4c6c54c4d05b/latest/USD";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var listOfCurrencies = JsonConvert.DeserializeObject<Currencies>(response);
                lvCurrencyFrom.ItemsSource = listOfCurrencies.conversion_rates.Keys;
                lvCurrencyTo.ItemsSource = listOfCurrencies.conversion_rates.Keys;


            }
        }

        private async void Convert(string currencyFrom, string currencyTo, string amount)
        {
            //https://v6.exchangerate-api.com/v6/YOUR-API-KEY/pair/EUR/GBP/AMOUNT
            string url = "https://v6.exchangerate-api.com/v6/3808ca223ddc4c6c54c4d05b/pair/" + currencyFrom + "/" + currencyTo + "/" + amount;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var conversion = JsonConvert.DeserializeObject<Conversion>(response);

                //Save the result and the rate to the user that made the conversion
                txtValue.Text = conversion.conversion_result.ToString();

            }
        }

        void lvCurrencyFrom_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItem = (String)listView.SelectedItem;

            txtCurrencyFrom.Text = selectedItem;
            //var id = selectedItem.Id;
            //var experience = selectedItem.Experience;
            //Navigation.PushAsync(new CourseDetailPage(id, experience));

            //Navigation.PushAsync(new CourseDetailPage(selectedItem));


        }
        void lvCurrencyTo_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItem = (String)listView.SelectedItem;

            txtCurrencyTo.Text = selectedItem;
        }
        void btnConvert_clicked(System.Object sender, System.EventArgs e)
        {
            string currencyFrom = txtCurrencyFrom.Text;
            string currencyTo = txtCurrencyTo.Text;
            string amount = txtValue.Text;
            Convert(currencyFrom, currencyTo, amount);
        }
        void btnList_clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListConversionPage());
        } 

        void txtSearchFrom_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var searched = sender.ToString();
            lvCurrencyFrom.FindByName(searched);

        }

        void txtSearchTo_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var searched = sender.ToString();
            var item = lvCurrencyTo.FindByName(searched);
            lvCurrencyTo.ItemsSource = (System.Collections.IEnumerable)item;
        }
    }
}
