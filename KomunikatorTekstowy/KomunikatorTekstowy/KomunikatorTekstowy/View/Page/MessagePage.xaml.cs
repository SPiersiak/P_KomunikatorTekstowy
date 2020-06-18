using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.ViewModel;
using KomunikatorTekstowy.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomunikatorTekstowy.View.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagePage : ContentPage
    {
        MessageViewModel viewModel;

        public MessagePage(MessageViewModel recipent)
        {
            InitializeComponent();
            BindingContext = viewModel = recipent;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Messages.Count == 0)
                viewModel.IsBusy = true;
        }
        private void SendMsg_Clicked(object sender, EventArgs e)
        {
            var message = new UserMessage() { Id = Guid.NewGuid().ToString(), Message = Message.Text, RecipentId = viewModel.Recip.UserId, SenderId = viewModel.SenderId, Time = DateTime.Now };
            MessagingCenter.Send(this, "SendMessage", message);
            Message.Text = "";
        }
    }
}