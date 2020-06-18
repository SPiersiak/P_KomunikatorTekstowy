using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomunikatorTekstowy.View.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserDetailsPage : ContentPage
    {
        EditUserViewModel viewModel;
        public EditUserDetailsPage(UserDetailData user)
        {
            InitializeComponent();
            BindingContext = new EditUserViewModel(user);
        }
        public EditUserDetailsPage()
        {
            InitializeComponent();
            var user = new UserDetailData();
            viewModel = new EditUserViewModel(user);
            BindingContext = viewModel;
        }

        private async void SaveUser_Clicked(object sender, EventArgs e)
        {
            await Task.Delay(400);
            await Navigation.PopAsync();
        }
        private async void CancelEditUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}