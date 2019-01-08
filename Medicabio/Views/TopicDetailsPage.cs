using System;

using Xamarin.Forms;

namespace Medicabio.Views
{
    public class TopicDetailsPage : ContentPage
    {
        public TopicDetailsPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

