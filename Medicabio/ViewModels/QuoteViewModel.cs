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
    public class QuoteViewModel : INotifyPropertyChanged
    {

        private List<Quote> quotes;

        public string Title { get; set; }

        public RestService restService { get; set; }

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
            Title = "Preventivi";
            Quotes = new List<Quote>();
            restService = new RestService();


            LoadQuotes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
