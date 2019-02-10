using System;
using System.Collections.Generic;
using Medicabio.Models;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class ManufacturersPage : ContentPage
    {
        ManufacturersViewModel viewModel;

        public ManufacturersPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ManufacturersViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Manufacturer;
            if (item == null)
                return;

            await Navigation.PushAsync(new ProductsPage(new ProductsViewModel(item.Id)));

            // Manually deselect item.
            ManufacturersListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Manufacturers.Count == 0)
                viewModel.LoadManufacturersCommand.Execute(null);
        }
    }
}
