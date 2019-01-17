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
            Console.WriteLine("chiamo oggeto quotes dalla vista");
            Console.WriteLine(viewModel.Quotes);
        }


        async void AddQuoteClick(object sender, EventArgs e)
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
            QuotesListView.SelectedItem = null;
        }
    }
}
