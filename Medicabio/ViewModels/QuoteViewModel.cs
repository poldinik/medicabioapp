using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class QuoteViewModel : BaseViewModel
    {

        private List<Quote> quotes;
        private ObservableCollection<ProductItem> productItems { get; set; }
        public ObservableCollection<ProductItem> ProductItems
        {
            get
            {
                return productItems;
            }
            set
            {
                productItems = value;
                OnPropertyChanged();
            }
        }



        public RestService restService { get; set; }
        public Command LoadProductItems { get; set; }

        public List<Quote> Quotes
        {
            get
            {
                return quotes;
            }
            set
            {
                quotes = value;
                OnPropertyChanged();
            }
        }
        
        

        public QuoteViewModel()
        {
            Title = "Preventivo";
            Quotes = new List<Quote>();
            ProductItems = new ObservableCollection<ProductItem>();

            //ProductItem productItem = new ProductItem();
            //productItem.Id = 1;
            //productItem.ArticleNumber = "dfsdsds";
            //productItem.Description = "descrizione";

            //ProductItems.Add(productItem);

            restService = new RestService();
            //LoadProductItems = new Command(async () => await ExecuteLoadProductItemsCommand());

            MessagingCenter.Subscribe<ProductPage, ProductItem>(this, "AddProductItem", (obj, item) =>
            {
                Debug.WriteLine("Aggiungo prodotto a preventivo");
                var newItem = item as ProductItem;
                Debug.WriteLine(newItem.ArticleNumber);
                ProductItems.Add(newItem);
                //ProductItems = ProductItems;
                //await DataStore.AddItemAsync(newItem);
            });

            //LoadQuotes();
        }

      


        async Task ExecuteLoadProductItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                ProductItems.Clear();
                //var items = await restService.GetResponse<List<Product>>(Constants.urlApi + "manufacturers/" + manufacturerId + "/products", true);
                var items = await App.QuoteProductDatabase.GetProductItemsAsync();

                ProductItems = new ObservableCollection<ProductItem>(items);

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


      

        public async void LoadQuotes()
        {
            Debug.Print("chiamo LoadQuotes");
            Quotes = await GetQuotesAsync();
            Console.WriteLine(Quotes);

        }

        public Task<List<Quote>> GetQuotesAsync()
        {
            Debug.WriteLine("get Quotes");
            return restService.GetResponse<List<Quote>>(Constants.urlApi +"agents/" + "1/" + "quotes", true);
        }

    }
}
