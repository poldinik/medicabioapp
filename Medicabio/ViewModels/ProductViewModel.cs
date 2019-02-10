using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;

namespace Medicabio.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {

        public RestService restService { get; set; }

        private Product product;

        public Product Product
        {
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


        public ProductViewModel(int Id)
        {
            Product = new Product();
            restService = new RestService();
            //LoadProduct(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void LoadProduct(int Id)
        {
            //List<Key> Keys = await GetKeysAsync();

            Product = await GetProductAsync(Id);
            Console.WriteLine(Product);
            //OKeys = new ObservableCollection<Key>(Keys as List<Key>);
            //Console.WriteLine(_okeys[1].id);
        }

      
        public Task<Product> GetProductAsync(int Id)
        {
            //return restService.GetResponse...
            Debug.WriteLine("get Product " + Id.ToString());
            return restService.GetResponse<Product>(Constants.urlApi + "products/"+Id.ToString(), false);
        }



    }
}
