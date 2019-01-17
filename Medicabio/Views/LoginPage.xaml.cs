using System;
using System.Collections.Generic;
using Medicabio.Models;
using Medicabio.ViewModels;
using Xamarin.Forms;

namespace Medicabio.Views
{
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var userCredentials = new UserCredentials();

            userCredentials.Email = emailEntry.Text;
            userCredentials.Password = passwordEntry.Text;


            //viewModel.LogIn(userCredentials);

            var isValid = AreCredentialsCorrect(userCredentials);
            if (isValid)
            {
                await Navigation.PushModalAsync(new AgentMainPage());
                 //awaitawait Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Login failed";
                passwordEntry.Text = string.Empty;
            }
        }

        private Boolean AreCredentialsCorrect(UserCredentials userCredentials)
        {
           return true;
        }
    }
}
