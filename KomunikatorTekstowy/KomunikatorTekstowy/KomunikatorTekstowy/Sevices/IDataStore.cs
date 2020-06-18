using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KomunikatorTekstowy.Sevices
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> FindItemAsync(string loginName);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);

    }
}
