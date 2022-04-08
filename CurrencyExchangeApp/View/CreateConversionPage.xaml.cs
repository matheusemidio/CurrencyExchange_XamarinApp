using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CurrencyExchangeApp.View
{
    public partial class CreateConversionPage : ContentPage
    {
        public CreateConversionPage()
        {
            InitializeComponent();
        }
        void lvCurrencyFrom_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //var listView = (ListView)sender;
            //var selectedItem = (Course)listView.SelectedItem;

            ////var id = selectedItem.Id;
            ////var experience = selectedItem.Experience;
            ////Navigation.PushAsync(new CourseDetailPage(id, experience));

            //Navigation.PushAsync(new CourseDetailPage(selectedItem));


        }
        void lvCurrencyTo_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //var listView = (ListView)sender;
            //var selectedItem = (Course)listView.SelectedItem;

            ////var id = selectedItem.Id;
            ////var experience = selectedItem.Experience;
            ////Navigation.PushAsync(new CourseDetailPage(id, experience));

            //Navigation.PushAsync(new CourseDetailPage(selectedItem));
        }
        void btnConvert_clicked(System.Object sender, System.EventArgs e)
        {

        }
        void btnList_clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ListConversionPage());

        }
        
    }
}
