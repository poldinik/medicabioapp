using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class QuoteDetailPage : ContentPage
    {
        public QuoteDetailPage()
        {
            InitializeComponent();

            var browser = new WebView();
            browser.Source = "http://xamarin.com";
            Content = browser;
        }
    }
}
