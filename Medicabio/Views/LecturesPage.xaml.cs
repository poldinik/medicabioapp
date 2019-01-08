using System;
using System.Collections.Generic;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Medicabio.ViewModels;
using Medicabio.Models;
using System.Diagnostics;

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


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Lecture;
            if (item == null)
            return;

            var id = item.Id.ToString();

            Debug.Print("chiamo on item selected");
            await Navigation.PushAsync(new LectureDetailsPage(new LectureDetailsViewModel(id)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }


    }
}
