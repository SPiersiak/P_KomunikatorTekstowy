using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KomunikatorTekstowy.View.Page;
using KomunikatorTekstowy.View.Menu;
using KomunikatorTekstowy.Sevices;
using Xamarin.Essentials;

namespace KomunikatorTekstowy
{
    public partial class App : Application
    {
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://192.168.0.107:45455" : "http://localhost:44352";
        public static bool UseMockDataStore = false;
        public App()
        {
            InitializeComponent();
            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();
            //MainPage = new RegistrationPage();
            MainPage = new NavigationPage(new LoginPage());
            
           
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
