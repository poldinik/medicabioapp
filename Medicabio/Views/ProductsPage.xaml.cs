using System;
using System.Collections.Generic;
using Medicabio.Models;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class ProductsPage : ContentPage
    {

        ProductsViewModel viewModel;

        public ProductsPage(ProductsViewModel productsViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = productsViewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Product;
            if (item == null)
                return;

            await Navigation.PushAsync(new ProductPage(item.Id.ToString()));

            // Manually deselect item.
            ProductsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Products.Count == 0)
                viewModel.LoadProductsCommand.Execute(null);
        }
    }
}
