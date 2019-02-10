using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;

namespace Medicabio.ViewModels
{
    public class ProductsViewModel : INotifyPropertyChanged
    {

        private List<Product> products;

        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public RestService restService { get; set; }

        private string manufacturerId;

        public ProductsViewModel(string ManufacturerId)
        {
            manufacturerId = ManufacturerId;
            Products = new List<Product>();
            restService = new RestService();

            LoadProducts();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void LoadProducts()
        {
            //List<Key> Keys = await GetKeysAsync();

            Products = await GetProductsAsync();
            Console.WriteLine(Products);
            //OKeys = new ObservableCollection<Key>(Keys as List<Key>);
            //Console.WriteLine(_okeys[1].id);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            //return restService.GetResponse...
            Debug.WriteLine("get Products");
            return restService.GetResponse<List<Product>>(Constants.urlApi + "manufacturers/" + manufacturerId+"/products", true);
        }

    }
}
