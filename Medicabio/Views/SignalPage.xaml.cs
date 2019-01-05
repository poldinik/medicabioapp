using System;
using System.Collections.Generic;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class SignalPage : ContentPage
    {
        AppointmentViewModel viewModel;

        public SignalPage()
        {
            InitializeComponent();
            viewModel = new AppointmentViewModel();
            BindingContext = viewModel;

        }

        async void AddAppointment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAppointmentPage()));
        }
    }
}