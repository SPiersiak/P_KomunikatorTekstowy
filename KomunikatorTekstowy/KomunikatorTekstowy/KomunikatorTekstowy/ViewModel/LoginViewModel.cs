using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.View.Menu;
using System.Collections.ObjectModel;
using System.Linq;
using KomunikatorTekstowy.View.Page;

namespace KomunikatorTekstowy.ViewModel
{
    class LoginViewModel :BaseViewModel
    {
        public ObservableCollection<UserDetailData> Users { get; set; }
        public UserDetailData User { get; set; }
        public Command LogInCommand { get; }
        public LoginViewModel()
        {
            LogInCommand = new Command(LogIn);
            Users = new ObservableCollection<UserDetailData>();
        }
        private async void LogIn()
        {
            IsBusy = true;
            if (string.IsNullOrEmpty(loginName) && string.IsNullOrEmpty(password))
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Błąd", "Nie wpisano danych", "OK");
            }
            else if(string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password))
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Błąd", "Nie wpisano loginu lub hasła", "OK");
            }
            else
            {
                Users.Clear();
                var a = await DataStore.GetItemsAsync(true);
                foreach(var x in a)
                {
                    Users.Add(x);
                }
                User = Users.FirstOrDefault(x => x.LoginName == loginName);

                if (User == null || User.Password != password)
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Błąd", "Niepoprawny login lub hasło", "OK");
                   
                }
                else
                {
                    IsBusy = false;
                    Application.Current.MainPage = new MenuPage(User);

                }

            }

        }
        string loginName = "";
        string password = "";
        public string LoginName
        {
            get { return loginName; }
            set
            {
                loginName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }



    }
}
