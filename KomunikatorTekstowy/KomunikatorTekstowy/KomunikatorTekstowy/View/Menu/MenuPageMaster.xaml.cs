using KomunikatorTekstowy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.View.Page;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomunikatorTekstowy.View.Menu
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class MenuPageMaster : ContentPage
    {
        MenuPage RootPage { get => Application.Current.MainPage as MenuPage; }
        List<HomeMenuItem> menuItems;
        //public ListView ListView;

        public MenuPageMaster()
        {
            InitializeComponent();
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem { id = MenuItemType.MyData, Title="User List"},
                new HomeMenuItem { id = MenuItemType.UserList, Title="My Detail Page"},
                new HomeMenuItem { id = MenuItemType.MessageUserList, Title="Communicator"},
            };

            MenuItemsListView.ItemsSource = menuItems;
            MenuItemsListView.SelectedItem = menuItems[0];
            MenuItemsListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                var id = (int)((HomeMenuItem)e.SelectedItem).id;
                await RootPage.NavigateFromMenu(id);
            };
            //BindingContext = new MenuPageMasterViewModel();
            //ListView = MenuItemsListView;
        }

        private  void Logout_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }

        //class MenuPageMasterViewModel : INotifyPropertyChanged
        //{
        //    public ObservableCollection<MenuPageMasterMenuItem> MenuItems { get; set; }

        //    public MenuPageMasterViewModel()
        //    {
        //        MenuItems = new ObservableCollection<MenuPageMasterMenuItem>(new[]
        //        {
        //            new MenuPageMasterMenuItem { Id = 0, Title = "Page 1" },
        //            new MenuPageMasterMenuItem { Id = 1, Title = "Page 2" },
        //            new MenuPageMasterMenuItem { Id = 2, Title = "Page 3" },
        //            new MenuPageMasterMenuItem { Id = 3, Title = "Page 4" },
        //            new MenuPageMasterMenuItem { Id = 4, Title = "Page 5" },
        //        });
        //    }

        //    #region INotifyPropertyChanged Implementation
        //    public event PropertyChangedEventHandler PropertyChanged;
        //    void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        if (PropertyChanged == null)
        //            return;

        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    #endregion
        //}
    }
}