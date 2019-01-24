using System;
using System.Collections.Generic;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class ProductsPage : ContentPage
    {

        ProductsViewModel viewModel;

        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductsViewModel();
        }
    }
}
