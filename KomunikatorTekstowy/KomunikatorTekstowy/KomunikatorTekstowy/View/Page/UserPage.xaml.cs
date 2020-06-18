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
    public partial class UserPage : ContentPage
    {
        UserViewModel viewModel;
        public UserPage(UserViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
        public UserPage()
        {
            InitializeComponent();
            var user = new UserDetailData();
            viewModel = new UserViewModel(user);
            BindingContext = viewModel;
        }
    }
}