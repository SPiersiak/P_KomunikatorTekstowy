using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.ViewModel;

namespace KomunikatorTekstowy.View.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailsPage : ContentPage
    {
        UserDetailViewModel viewModel;
        UserDetailData User { get; set; }

        public UserDetailsPage(UserDetailData user)
        {
            InitializeComponent();
            this.User = user;
            BindingContext = viewModel = new UserDetailViewModel(User);

        }

        private void EditUser_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new EditUserDetailsPage(User));
        }
    }
}