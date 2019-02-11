using System;
using System.Collections.Generic;
using System.Diagnostics;
using Medicabio.Models;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class ProductPage : ContentPage
    {

        ProductViewModel viewModel;
        Product product;
        public ProductPage(string Id)
        {
            InitializeComponent();
            BindingContext = viewModel = new ProductViewModel(Id.ToString());
            product = viewModel.Product;
        }

        //async void AddProductToQuote_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}


        async void AddProductToQuote_Clicked(object sender, EventArgs args)
        {

            ProductItem productItem = new ProductItem();
            productItem.Id = product.Id;
            productItem.ArticleNumber = product.ArticleNumber;
            productItem.Description = product.Description;
            await App.QuoteProductDatabase.SaveProductItemAsync(productItem);
            //Debug.Write("Salvo oggetto");
            //Debug.WriteLine(await App.QuoteProductDatabase.SaveProductItemAsync(productItem));
            await Navigation.PopAsync();
        }
    }
}
