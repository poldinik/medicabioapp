using System;
using System.Collections.Generic;
using Medicabio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Medicabio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopicsPage : ContentPage
    {
        TopicsViewModel viewModel;

        public TopicsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new TopicsViewModel();
        }
    }
}
