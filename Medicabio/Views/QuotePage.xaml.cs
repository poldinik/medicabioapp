using System;
using System.Collections.Generic;
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

            BindingContext = viewModel = new QuoteViewModel(1);
        }


        async void AddQuoteClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewQuotePage()));
        }
    }
}
