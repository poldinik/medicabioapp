using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Medicabio.Models;
using Medicabio.Services;
using Xamarin.Forms;

namespace Medicabio.ViewModels
{
    public class ManufacturersViewModel : BaseViewModel
    {

        public ObservableCollection<Manufacturer> Manufacturers { get; set; }
        public Command LoadManufacturersCommand { get; set; }

        private RestService restService { get; set; }

        public ManufacturersViewModel()
        {
            restService = new RestService();
            Title = "Prodotti";
            Manufacturers = new ObservableCollection<Manufacturer>();
            LoadManufacturersCommand = new Command(async () => await ExecuteLoadManufacturersCommand());
        }


        async Task ExecuteLoadManufacturersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Manufacturers.Clear();
                var items = await restService.GetResponse<List<Manufacturer>>(Constants.urlApi + "manufacturers", true);
                foreach (var item in items)
                {
                    Manufacturers.Add(item);
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
