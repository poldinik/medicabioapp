using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;

namespace Medicabio.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public RestService restService { get; set; }

        public Boolean isLogged;

        private SecurityToken securityToken;
        public SecurityToken SecurityToken
        {
            get
            {
                return securityToken;
            }

            set
            {
                securityToken = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel()
        {
            isLogged = false;
            restService = new RestService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            Debug.WriteLine("property name: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async void LogIn(UserCredentials userCredentials)
        {
            //List<Key> Keys = await GetKeysAsync();

            SecurityToken = await LogInAsync(userCredentials);
            //OKeys = new ObservableCollection<Key>(Keys as List<Key>);
            //Console.WriteLine(_okeys[1].id);
        }

        public Task<SecurityToken> LogInAsync(UserCredentials userCredentials)
        {
            //return restService.GetResponse...
            Debug.WriteLine("get Token from login");
            return restService.PostResponse<SecurityToken>(Constants.urlApi + "signin", "");
        }
    }
}
