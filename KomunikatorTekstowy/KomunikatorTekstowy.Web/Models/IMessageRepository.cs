using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomunikatorTekstowy.Web.Models
{
    public interface IMessageRepository
    {
        void AddMessage(UserMessage m);
        UserMessage GetMessage(string id);
        IEnumerable<UserMessage> GetAllMessage();
    }
}
