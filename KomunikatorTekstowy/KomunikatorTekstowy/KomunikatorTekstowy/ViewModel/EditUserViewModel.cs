using System;
using System.Collections.Generic;
using System.Text;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.View.Page;
using Xamarin.Forms;

namespace KomunikatorTekstowy.ViewModel
{
    class EditUserViewModel :BaseViewModel
    {
        public UserDetailData User { get; set; }

        public EditUserViewModel(UserDetailData user)
        {
            SaveEditUserCommand = new Command(save);
            User = user;
        }
        public Command SaveEditUserCommand { get; }
        public async void save()
        {

            await DataStore.UpdateItemAsync(User);
            await Application.Current.MainPage.DisplayAlert("Save", "Change has been saved", "OK");

        }

        public string Id
        {
            get { return User.UserId; }
            set
            {
                User.UserId = User.UserId;
            }
        }
        public string FName
        {
            get { return User.FirstName; }
            set
            {
                User.FirstName = value;

                OnPropertyChanged();

            }
        }
        public string LName
        {
            get { return User.LastName; }
            set
            {
                User.LastName = value;

                OnPropertyChanged();
            }
        }
        public string Mail
        {
            get { return User.EmailAddress; }
            set
            {
                User.EmailAddress = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get { return User.PhoneNumber; }
            set
            {
                User.PhoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string NumberOfAlbum
        {
            get { return User.NumberOfAlbum; }
            set
            {
                User.NumberOfAlbum = value;

                OnPropertyChanged();
            }
        }
        public string Url
        {
            get { return User.WebsiteLink; }
            set
            {
                User.WebsiteLink = value;

                OnPropertyChanged();
            }
        }
    }
}
