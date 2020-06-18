using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KomunikatorTekstowy.Models;

namespace KomunikatorTekstowy.Sevices
{
    public interface IDataMessage<T>
    {
        Task<bool> AddMessageAsync(UserMessage mess);
        Task<T> GetMessageAsync(string id);
        Task<IEnumerable<T>> GetMessagesAsync(bool forceRefresh = false);
    }
}
