using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomunikatorTekstowy.Web.Data;

namespace KomunikatorTekstowy.Web.Models
{
    public class MessageRepository : IMessageRepository
    {
        private AppDbContext _dbContext;
        public MessageRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void AddMessage(UserMessage m)
        {
            _dbContext.UserMessage.Add(m);
            _dbContext.SaveChanges();
        }
        public UserMessage GetMessage(string id)
        {
            return _dbContext.UserMessage.Find(id);
        }
        public IEnumerable<UserMessage> GetAllMessage()
        {
            return _dbContext.UserMessage.ToList();
        }
    }
}
