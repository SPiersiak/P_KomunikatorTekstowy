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
    public partial class MessageUserListPage : ContentPage
    {
        MessageUserListViewModel viewModel;
        String Id = "";
        public MessageUserListPage(string id)
        {
            InitializeComponent();
            this.Id = id;
            BindingContext = viewModel = new MessageUserListViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Users.Count == 0)
                viewModel.IsBusy = true;
        }
        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (UserDetailData)layout.BindingContext;
            await Navigation.PushAsync(new MessagePage(new MessageViewModel(item, Id)));
        }
    }
}