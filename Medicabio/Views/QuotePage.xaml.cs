using System;
using System.Collections.Generic;
using System.Diagnostics;
using Medicabio.Models;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class QuotePage : ContentPage
    {
        QuoteViewModel viewModel;

        public QuotePage()
        {
            InitializeComponent();

            BindingContext = viewModel = new QuoteViewModel();


        }


        async void SendQuoteClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewQuotePage()));
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Quote;
            if (item == null)
                return;

            var id = item.Id.ToString();

            Debug.Print("chiamo on item selected da quote page");
            await Navigation.PushAsync(new QuoteDetailPage());

            // Manually deselect item.
            ProductListView.SelectedItem = null;
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    // Reset the 'resume' id, since we just want to re-start here
        //    Console.WriteLine(await App.QuoteProductDatabase.GetProductItemsAsync());
        //    //ProductListView.ItemsSource = await App.QuoteProductDatabase.GetProductItemsAsync();
        //}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (viewModel.ProductItems.Count == 0 || viewModel.ProductItems == null)
        //        viewModel.LoadProductItems.Execute(null);
        //}
    }
}
