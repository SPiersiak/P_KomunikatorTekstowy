using KomunikatorTekstowy.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace KomunikatorTekstowy.Sevices
{
    class MockDataStore : IDataStore<UserDetailData>
    {
        readonly List<UserDetailData> items;

        public MockDataStore()
        {
            //items = new List<UserDetailData>()
            //{
            //    new UserDetailData { Id = 1, FName="Szymon", LName="Piersiak", Mail="piersiak.szymon@gmail.com", PhonNumber="662385925",NumberOfAlbum="61068", Url="http://www.linkedin.com" },
            //    new UserDetailData { Id = 2, FName="Adam", LName="Nowak", Mail="nowak.adam@gmail.com", PhonNumber="123456789",NumberOfAlbum="12345", Url="http://www.linkedin.com" },
            //};
        }

        public async Task<bool> AddItemAsync(UserDetailData item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(UserDetailData item)
        {
            var oldItem = items.Where((UserDetailData arg) => arg.UserId == item.UserId).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
        public async Task<UserDetailData> FindItemAsync(string loginName)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.UserId == loginName));
            //tak o zrobione
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((UserDetailData arg) => arg.UserId == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<UserDetailData> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.UserId == id));
        }

        public async Task<IEnumerable<UserDetailData>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}

