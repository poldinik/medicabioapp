using System;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Medicabio.ViewModels;

namespace Medicabio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LecturesPage : ContentPage
    {
        LecturesViewModel viewModel;

        public LecturesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new LecturesViewModel();
        }


    }
}
