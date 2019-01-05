using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;

namespace Medicabio.ViewModels
{
    public class LecturesViewModel : INotifyPropertyChanged
    {
        private List<Lecture> lectures;
        public List<Lecture> Lectures
        {
            get
            {
                return lectures;
            }
            set
            {
                lectures = value;
                OnPropertyChanged();
            }
        }


        public string Title { get; set; }
        public RestService restService { get; set; }

        public LecturesViewModel()
        {
            Title = "Corsi";
            Lectures = new List<Lecture>();

            restService = new RestService();

            //var mockItems = new List<Lecture>
            //{
            //    new Lecture { Title = "Clinical immersion", Description = "Riparazione protesica dell'ernia inguinale", Date = "23-10-2018 14:00", Location = "Azienda ospedaliero - universitaria Pisana", City = "Pisa" },
            //    new Lecture { Title = "Woundcare", Description = "Descrizione evento woundcare", Date = "22-11-2018 15:00", Location = "Hotel Mediterraneo", City = "Firenze" }
            //};

            //foreach (var item in mockItems)
            //{
            //    Lectures.Add(item);
            //}

            LoadLectures();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadLectures()
        {
            //List<Key> Keys = await GetKeysAsync();

            Lectures = await GetLecturesAsync();
            Console.WriteLine(Lectures);
            //OKeys = new ObservableCollection<Key>(Keys as List<Key>);
            //Console.WriteLine(_okeys[1].id);
        }

        public Task<List<Lecture>> GetLecturesAsync()
        {
            //return restService.GetResponse...
            Debug.WriteLine("get Lectures");
            return restService.GetResponse<List<Lecture>>(Constants.urlApi + "lectures", true);
        }

    }
}
