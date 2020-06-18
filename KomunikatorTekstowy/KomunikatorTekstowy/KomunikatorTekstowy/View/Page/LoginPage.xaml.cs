using KomunikatorTekstowy.View.Menu;
using KomunikatorTekstowy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomunikatorTekstowy.View.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private void RegistrationButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        } 
        //private void LogInButton_Clicked(object sender, EventArgs e)
        //{
        //    //Application.Current.MainPage = new MenuPage();
        //    //Navigation.PushAsync(new MenuPage());
        //    //Navigation.RemovePage(Navigation.NavigationStack.First());
        //}
    }
}