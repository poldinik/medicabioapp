using System;
using System.Collections.Generic;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class ProductPage : ContentPage
    {

        ProductViewModel viewModel;

        public ProductPage(int Id)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductViewModel(Id);
        }
    }
}
