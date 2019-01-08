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
    public class TopicsViewModel : INotifyPropertyChanged
    {
        private List<Topic> topics { get; set; }

        public List<Topic> Topics
        {
            get
            {
                return topics;
            }
            set
            {
                topics = value;
                OnPropertyChanged();
            }
        }

        public RestService restService { get; set; }

        public string Title { get; set; }

        public TopicsViewModel()
        {
            Title = "Argomenti";
            Topics = new List<Topic>();

            //var mockItems = new List<Topic>
            //{
            //    new Topic { Title = "Ernie" },
            //    new Topic { Title = "Woundcare" }
            //};

            //foreach (var item in mockItems)
            //{
            //    Topics.Add(item);
            //}

            restService = new RestService();
            LoadTopics();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Task<List<Topic>> GetTopicsAsync()
        {
            //return restService.GetResponse...
            Debug.WriteLine("get Topics");
            return restService.GetResponse<List<Topic>>(Constants.urlApi + "topics", true);
        }

        public async void LoadTopics()
        {
            Topics = await GetTopicsAsync();
            Console.WriteLine(Topics);
        }
    }
}
