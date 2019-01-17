using System;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Medicabio.ViewModels;

namespace Medicabio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;

        public HomePage()
        {
            BindingContext = viewModel = new HomeViewModel();
            //this.chart.Chart= viewModel.GoalsChart;
            InitializeComponent();


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

          

            this.chartView.Chart = viewModel.GoalsChart;
            this.chartView2.Chart = viewModel.AppointmentChart;
        }

        async void OnAgentButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AgentPage()));
        }
    }
}
