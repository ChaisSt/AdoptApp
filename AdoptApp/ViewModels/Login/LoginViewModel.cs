using AdoptApp.Database;
using AdoptApp.Models;
using AdoptApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AdoptApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Login _login { get; set; }
        public Login login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            login = new Login();
            login.UserName = "";
            login.Password = "";
            login.AcctType = "";
            lblInfo = "";
        }

        private async void OnLoginClicked(object obj)
        {
            AdoptDatabase adoptDB = new AdoptDatabase();
            string userName = login.UserName;
            string password = login.Password;
            if (userName != null || userName != "" || password != null || password != "")
            {
                Login check = adoptDB.GetLogin(userName);
                if (check.UserName == userName && check.Password == password)
                {
                    if (check.AcctType == "Family")
                    {
                        await Shell.Current.GoToAsync($"//{nameof(UserProfile)}");
                    }
                    else if (login.AcctType == "Worker")
                    {
                        await Shell.Current.GoToAsync($"//{nameof(WorkerProfile)}");
                    }
                    else { lblInfo = "There was an error - Account type"; }
                }
                else { lblInfo = "Incorrect username and/or password, please try again."; }
            }
            else { lblInfo = "Please enter a username and password."; }
        }

        private string _lblInfo { get; set; }
        public string lblInfo
        {
            get { return _lblInfo; }
            set
            {
                _lblInfo = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
