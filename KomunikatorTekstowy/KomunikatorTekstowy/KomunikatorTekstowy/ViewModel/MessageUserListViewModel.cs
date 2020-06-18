using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using KomunikatorTekstowy.Models;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KomunikatorTekstowy.ViewModel
{
    public class MessageUserListViewModel :BaseViewModel
    {
        public ObservableCollection<UserDetailData> Users { get; set; }
        public Command LoadItemsCommand { get; set; }
        public MessageUserListViewModel()
        {
            Title = "Communicator";
            Users = new ObservableCollection<UserDetailData>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                var users = await DataStore.GetItemsAsync(true);
                foreach (var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
