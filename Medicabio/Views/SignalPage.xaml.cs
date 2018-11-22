using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class SignalPage : ContentPage
    {
        public SignalPage()
        {
            InitializeComponent();
        }

        async void AddAppointment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewAppointmentPage()));
        }
    }
}
