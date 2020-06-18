using System;
using System.Collections.Generic;
using System.Text;
using KomunikatorTekstowy.Models;
using Xamarin.Forms;
using KomunikatorTekstowy.View.Page;
using System.Threading.Tasks;
using System.Diagnostics;
//using static System.Net.Mime.MediaTypeNames;

namespace KomunikatorTekstowy.ViewModel
{
    public class UserDetailViewModel :BaseViewModel
    {
        public Command RefreshUserCommand { get; }
        public UserDetailData User { get; set; }

        public UserDetailViewModel(UserDetailData user)
        {
            RefreshUserCommand = new Command(Refresh);
            Title = "My page";
            this.User = user;
            Name = User.FirstName + " " + User.LastName;
            NOAlbum = User.NumberOfAlbum;
            Description = User.Description;
            PNumber = User.PhoneNumber;
            Email = User.EmailAddress;
            WebUrl = User.WebsiteLink;
            ImageS = User.Photo;
        }

        public async void Refresh()
        {
            var user = await DataStore.GetItemAsync(User.UserId);
            this.User = user;
            Name = User.FirstName + " " + User.LastName;
            NOAlbum = User.NumberOfAlbum;
            Description = User.Description;
            PNumber = User.PhoneNumber;
            Email = User.EmailAddress;
            WebUrl = User.WebsiteLink;
        }
        public string name = "";
        public string nOAlbum = "";
        public string description = "";
        public string pNumber = "";
        public string email = "";
        public string webUrl = "";
        public byte[] imgeS;
        public byte[] ImageS
        {
            get { return imgeS; }
            set
            {
                imgeS = User.Photo;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = User.FirstName + " " + User.LastName;
                OnPropertyChanged();
            }
        }
        public string NOAlbum
        {
            get { return nOAlbum; }
            set
            {
                nOAlbum = User.NumberOfAlbum;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = User.Description;
                OnPropertyChanged();
            }
        }
        public string PNumber
        {
            get { return pNumber; }
            set
            {
                pNumber = User.PhoneNumber;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = User.EmailAddress;
                OnPropertyChanged();
            }
        }
        public string WebUrl
        {
            get { return webUrl; }
            set
            {
                webUrl = User.WebsiteLink;
                OnPropertyChanged();
            }
        }
    }
}
