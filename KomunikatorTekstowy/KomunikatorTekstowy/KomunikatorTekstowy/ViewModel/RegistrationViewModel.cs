using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.View.Page;
using Plugin.Media;
using Xamarin.Forms;

namespace KomunikatorTekstowy.ViewModel
{
    class RegistrationViewModel :BaseViewModel
    {
        public UserDetailData User { get; set; }
        public Command RegisterCommand { get; }
        public Command AddPhotoCommand { get; }
        private Plugin.Media.Abstractions.MediaFile file = null;
        public RegistrationViewModel()
        {
            RegisterCommand = new Command(Register);
            AddPhotoCommand = new Command(AddPhoto);

        }

        public async void AddPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No upload","Picking a photo is not supported","Ok");
                return;
            }
            file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            ImageS = ImageSource.FromStream(() => file.GetStream()).ToString();
        }
        private byte[] ImageToBytes()
        {
            if (file == null)
                return null;
            using (var x = new MemoryStream())
            {
                file.GetStream().CopyTo(x);
                file.Dispose();
                return x.ToArray();
            }
        }
        public async void Register()
        {
            if (string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(numberOfAlbum))
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Wymagane pola nie zostały uzupelnione", "OK");
            }
            else
            {
                User = new UserDetailData
                {
                    UserId = Guid.NewGuid().ToString(),
                    LoginName = loginName,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    NumberOfAlbum = numberOfAlbum,
                    PhoneNumber = phoneNumber,
                    Description = desription,
                    Photo = ImageToBytes(),
                    EmailAddress = email,
                    WebsiteLink = webLink
                };
                await DataStore.AddItemAsync(User);
                await Application.Current.MainPage.DisplayAlert("Zarejstrowano", "Konto zostało założone", "OK");
            }
        }
        public string loginName = "";
        public string password = "";
        public string firstName = "";
        public string lastName = "";
        public string email = "";
        public string numberOfAlbum = "";
        public string desription = "";
        public string phoneNumber = "";
        public string webLink = "";
        public string imageSource = "";

        public string ImageS
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged();
            }
        }
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
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
        public string NumberOfAlbum
        {
            get { return numberOfAlbum; }
            set
            {
                numberOfAlbum = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return desription; }
            set
            {
                desription = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }
        public string WebLink
        {
            get { return webLink; }
            set
            {
                webLink = value;
                OnPropertyChanged();
            }
        }
    }
}
