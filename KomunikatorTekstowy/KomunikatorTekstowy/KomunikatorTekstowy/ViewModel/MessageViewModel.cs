using System;
using System.Collections.Generic;
using System.Text;
using KomunikatorTekstowy.ViewModel;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.View.Page;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

namespace KomunikatorTekstowy.ViewModel
{
    public class MessageViewModel :BaseViewModel
    {
        public ObservableCollection<UserMessage> Messages { get; set; }
        public Command LoadMessagesCommand { get; set; }
        public UserDetailData Recip;
        public string SenderId;
       // public Command SendCommand { get; }
       // public UserMessage UM { get; set; }
        public MessageViewModel(UserDetailData recip, string senderId)
        {
            Recip = recip;
            Title = Recip.FirstName + " " + Recip.LastName;
            SenderId = senderId;
            Messages = new ObservableCollection<UserMessage>();

            LoadMessagesCommand = new Command(async () => await ExecuteLoadMessages());
            //SendCommand = new Command(Send);
            MessagingCenter.Subscribe<MessagePage, UserMessage>(this, "SendMessage", async (obj, message) =>
            {
                var newMessage = message as UserMessage;
                await MessageStore.AddMessageAsync(newMessage);
                Messages.Add(newMessage);

            });
        }
        //public async void Send()
        //{
        //    UM.Id = Guid.NewGuid().ToString();
        //    UM.Message = mes;
        //    UM.RecipentId = Recip.UserId;
        //    UM.SenderId = SenderId;
        //    UM.Time = DateTime.Now;
        //    await MessageStore.AddMessageAsync(UM);
        //    Mes = "";
        //}
        //public string mes = "";
        //public string Mes
        //{
        //    get { return mes; }
        //    set
        //    {
        //        mes = value;
        //        OnPropertyChanged();
        //    }
        //}
        async Task ExecuteLoadMessages()
        {
            Messages.Clear();
            IsBusy = true;
            var messages = await MessageStore.GetMessagesAsync(true);
            var sendId = SenderId;
            var recipId = Recip.UserId;
            messages = messages.OrderBy(s => s.Time);
            foreach (var msg in messages)
            {

                if (msg.RecipentId.Equals(recipId) && msg.SenderId.Equals(sendId))
                {
                    msg.Message = "Send: " + msg.Message;
                    Messages.Add(msg);
                }
                if (msg.SenderId.Equals(recipId) && msg.RecipentId.Equals(sendId))
                {
                    msg.Message = "Received: " + msg.Message;
                    Messages.Add(msg);
                }
            }
            IsBusy = false;
        }
    }
}


