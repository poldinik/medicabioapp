using System;
using System.Collections.Generic;
using System.Diagnostics;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class LectureDetailsPage : ContentPage
    {
        LectureDetailsViewModel viewModel;

        public LectureDetailsPage(LectureDetailsViewModel lectureDetailsViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = lectureDetailsViewModel;

            //Debug.Print("Titolo della lezione recuperata" + viewModel.Lecture.LectureDetails.Title);
        }


        async void OnScheduleButtonClick(object sender, SelectedItemChangedEventArgs args)
        {
            Debug.Print("Evento click su schedule");
        }

        async void OnRegisterButtonClick(object sender, SelectedItemChangedEventArgs args)
        {

        }

    }
}
