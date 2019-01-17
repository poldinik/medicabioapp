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
        public long AgentId { get; set; }

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

        public QuoteViewModel(long AgentId)
        {
            restService = new RestService();
            this.AgentId = AgentId;

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

            Quotes = await GetQuotesAsync();

        }

        public Task<List<Quote>> GetQuotesAsync()
        {
            Debug.WriteLine("get Quotes");
            return restService.GetResponse<List<Quote>>(Constants.urlApi + AgentId.ToString()+ "/" + "quote", true);
        }

    }
}
