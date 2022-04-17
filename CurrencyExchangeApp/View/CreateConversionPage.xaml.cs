using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyExchangeApp.Model;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Forms;

namespace CurrencyExchangeApp.View
{
    public partial class CreateConversionPage : ContentPage
    {

        List<string> listOfCurrenciesFrom = new List<string>();
        List<string> listOfCurrenciesTo = new List<string>();


        public CreateConversionPage()
        {
            InitializeComponent();

            GetCurrencies();

        }

        private async Task GetCurrencies()
        {
            string url = "https://v6.exchangerate-api.com/v6/3808ca223ddc4c6c54c4d05b/latest/USD";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var listOfCurrencies = JsonConvert.DeserializeObject<Currencies>(response);

                listOfCurrenciesFrom = new List<string>(listOfCurrencies.conversion_rates.Keys);
                listOfCurrenciesTo = new List<string>(listOfCurrencies.conversion_rates.Keys);

                lvCurrencyFrom.ItemsSource = listOfCurrenciesFrom;
                lvCurrencyTo.ItemsSource = listOfCurrenciesTo;


            }
        }

        private async void Convert(string currencyFrom, string currencyTo, string amount)
        {
            //https://v6.exchangerate-api.com/v6/3808ca223ddc4c6c54c4d05b/pair/EUR/GBP/AMOUNT
            Operation operation;
            string url = "https://v6.exchangerate-api.com/v6/3808ca223ddc4c6c54c4d05b/pair/" + currencyFrom + "/" + currencyTo + "/" + amount;
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var conversion = JsonConvert.DeserializeObject<Conversion>(response);


                operation = new Operation() {
                    UserId = App.loggedUser.Id.ToString(),
                    FromCurrency = currencyFrom,
                    ToCurrency = currencyTo,
                    Rate = conversion.conversion_rate.ToString(),
                    Amount = amount,
                    Value = conversion.conversion_result.ToString()
                };
                //Save the result and the rate to the user that made the conversion
                txtValue.Text = conversion.conversion_result.ToString();
                //conversion.conversion_rate.ToString();
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Operation>();
                int row = conn.Insert(operation);
                if (row > 0)
                {
                    DisplayAlert("Success", "Transaction was saved.", "Ok");
                    txtValue.Text = "";

                }
                else
                {
                    DisplayAlert("Failed", "Transaction was not saved", "Ok");
                }

            }
        }

        void lvCurrencyFrom_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItem = (String)listView.SelectedItem;

            txtCurrencyFrom.Text = selectedItem;

        }
        void lvCurrencyTo_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedItem = (String)listView.SelectedItem;

            txtCurrencyTo.Text = selectedItem;
            
        }
        void btnConvert_clicked(System.Object sender, System.EventArgs e)
        {
            if (txtCurrencyFrom.Text == "" || txtCurrencyTo.Text == "" || txtValue.Text == "")
            {
                DisplayAlert("Failed", "The fields can not be empty", "Ok");

            }
            else
            {
                string currencyFrom = txtCurrencyFrom.Text;
                string currencyTo = txtCurrencyTo.Text;
                string amount = txtValue.Text;
                Convert(currencyFrom, currencyTo, amount);
            }

        }
        void btnList_clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListConversionPage());
        }

        async void txtSearchFrom_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //var searched = sender.ToString();
            var searched = e.NewTextValue.ToString().ToUpper();

            
            Console.WriteLine(searched);

            if (searched.Length == 0)
            {
                await GetCurrencies();
                return;
            }
            else
            {
                List<string> filteredList = new List<string>();

                foreach (string i in listOfCurrenciesTo)
                {
                    if (i.Contains(searched))
                    {
                        filteredList.Add(i);
                    }
                }
                lvCurrencyFrom.ItemsSource = filteredList;
            }

        }

        async void txtSearchTo_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            //var searched = sender.ToString();
            var searched = e.NewTextValue.ToString().ToUpper();


            Console.WriteLine(searched);

            if (searched.Length == 0)
            {
                await GetCurrencies();
                return;
            } else
            {
                List<string> filteredList = new List<string>();

                foreach(string i in listOfCurrenciesTo)
                {
                    if (i.Contains(searched))
                    {
                        filteredList.Add(i);
                    }
                }
                lvCurrencyTo.ItemsSource = filteredList;
            }
        }
    }
}
