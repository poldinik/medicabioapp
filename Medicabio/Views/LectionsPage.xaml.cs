using System;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Medicabio.ViewModels;

namespace Medicabio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectionsPage : ContentPage
    {
        LectionsViewModel viewModel;

        public LectionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LectionsViewModel();
        }


    }
}
