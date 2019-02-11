using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;
using Medicabio.Views;
using Xamarin.Forms;

namespace Medicabio.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        private Product product { get; set; }
        public Product Product {
            get
            {
                return product;
            }
            set
            {
                product = value;
                OnPropertyChanged();
            }
        }
        public Command LoadProductCommand { get; set; }
        public RestService restService { get; set; }


        private string productId;

        public ProductViewModel(string ProductId)
        {
            productId = ProductId;
            restService = new RestService();
            Product = new Product();
            LoadProductCommand = new Command(async () => await ExecuteLoadProductCommand());

            //MessagingCenter.Subscribe<ProductPage, Product>(this, "AddProduct", async (obj, item) =>
            //{
            //    var newItem = item as Product;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});


            LoadProduct();
        }

        public async void LoadProduct()
        {
            Product = await GetProductAsync();
            Console.WriteLine(Product);
        }

        public Task<Product> GetProductAsync()
        {
            Debug.WriteLine("get Product " + productId);
            return restService.GetResponse<Product>(Constants.urlApi + "products/" + productId, false);
        }

        async Task ExecuteLoadProductCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var item = await restService.GetResponse<Product>(Constants.urlApi + "products/" + productId, false);
                Product = item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}
