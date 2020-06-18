using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.ViewModel;
using KomunikatorTekstowy.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace KomunikatorTekstowy.View.Page
{
    [DesignTimeVisible(false)]
    public partial class UserListPage : ContentPage
    {
        UserListViewModel viewModel;
        public UserListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserListViewModel();
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
            await Navigation.PushAsync(new UserPage(new UserViewModel(item)));
        }
    }
}