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
         
        }
    }
}
