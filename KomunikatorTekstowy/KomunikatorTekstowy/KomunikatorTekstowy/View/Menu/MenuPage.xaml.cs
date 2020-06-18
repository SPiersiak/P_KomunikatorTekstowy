using KomunikatorTekstowy.Models;
using KomunikatorTekstowy.View.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KomunikatorTekstowy.View.Menu
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
   [DesignTimeVisible(false)]
    public partial class MenuPage : MasterDetailPage
    {
        public UserDetailData User { get; set; }
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MenuPage(UserDetailData user)
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.MyData, (NavigationPage)Detail);
            User = user;
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.MyData:
                        MenuPages.Add(id, new NavigationPage(new UserListPage()));
                        
                        break;
                    case (int)MenuItemType.UserList:
                        MenuPages.Add(id, new NavigationPage(new UserDetailsPage(User)));
                        break;
                    case (int)MenuItemType.MessageUserList:
                        MenuPages.Add(id, new NavigationPage(new MessageUserListPage(User.UserId)));
                        break;
                }
            }
            var newPage = MenuPages[id];
            if(newPage != null && Detail != newPage)
            {
                Detail = newPage;
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);
                IsPresented = false;
            }
        }
        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MenuPageMasterMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    MasterPage.ListView.SelectedItem = null;
        //}
    }
}