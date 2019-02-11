using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Medicabio.Views;
using System.IO;
using Medicabio.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Medicabio
{
    public partial class App : Application
    {
        static QuoteProductsDatabase quoteProductDabase;

        public App()
        {
            InitializeComponent();


            MainPage = new LoginPage(new ViewModels.LoginViewModel());
        }

        public static QuoteProductsDatabase QuoteProductDatabase
        {
            get
            {
                if (quoteProductDabase == null)
                {
                    quoteProductDabase = new QuoteProductsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MedicabioSQLite.db3"));
                }
                return quoteProductDabase;
            }
        }

       //public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
