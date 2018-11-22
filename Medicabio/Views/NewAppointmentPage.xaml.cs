using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class NewAppointmentPage : ContentPage
    {
        public NewAppointmentPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}
