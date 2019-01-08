using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;

namespace Medicabio.ViewModels
{
    public class LectureDetailsViewModel : INotifyPropertyChanged
    {
        private Lecture lecture { get; set; }

        public Lecture Lecture
        {
            get 
            {
                return lecture; 
            }

            set
            {
                lecture = value;
                OnPropertyChanged();
            }
        }

        private string LectureId;

        public RestService restService { get; set; }

        public LectureDetailsViewModel(String LectureId)
        {
            Lecture = new Lecture();

            this.LectureId = LectureId;

            restService = new RestService();

            LoadLecture();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void LoadLecture()
        {
            Lecture = await GetLectureAsync();
            Console.WriteLine(Lecture);
        }

        private Task<Lecture> GetLectureAsync()
        {
            Debug.WriteLine("get Lecture " + LectureId);
            return restService.GetResponse<Lecture>(Constants.urlApi + "lectures"+ "/" + LectureId, false);
        }
    }
}
