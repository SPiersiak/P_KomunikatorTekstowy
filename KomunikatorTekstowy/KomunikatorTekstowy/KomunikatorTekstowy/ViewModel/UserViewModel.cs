using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using KomunikatorTekstowy.Models;

namespace KomunikatorTekstowy.ViewModel
{
    public class UserViewModel :BaseViewModel
    {
        public UserDetailData User { get; set; }
        public UserViewModel(UserDetailData user)
        {
            this.User = user;
            Title = User.FirstName + " " + User.LastName;
            string site = "http://" + User.WebsiteLink;
            OpenWebsiteCommand = new Command(async () => await Browser.OpenAsync(site));
            SendEmailCommand = new Command(async () => await Email.ComposeAsync("", "", User.EmailAddress));
            var message = new SmsMessage("", new[] { User.PhoneNumber });
            SendSmsCommand = new Command(async () => await Sms.ComposeAsync(message));

        }
        public ICommand OpenWebsiteCommand { get; }
        public ICommand SendSmsCommand { get; }
        public ICommand SendEmailCommand { get; }
    }
}
