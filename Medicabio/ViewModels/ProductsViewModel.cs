using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;
using Xamarin.Forms;

namespace Medicabio.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        public ObservableCollection<Product> Products { get; set; }
        public Command LoadProductsCommand { get; set; }

        private RestService restService { get; set; }

        private string manufacturerId;

        public ProductsViewModel(string ManufacturerId)
        {
            manufacturerId = ManufacturerId;
            restService = new RestService();
            Title = "Prodotti";
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
        }

        async Task ExecuteLoadProductsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Products.Clear();
                var items = await restService.GetResponse<List<Product>>(Constants.urlApi + "manufacturers/" + manufacturerId + "/products", true);
                foreach (var item in items)
                {
                    Products.Add(item);
                }
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
