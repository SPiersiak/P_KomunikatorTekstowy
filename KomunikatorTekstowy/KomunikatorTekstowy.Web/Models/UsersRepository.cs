using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomunikatorTekstowy.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace KomunikatorTekstowy.Web.Models
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _dbContext;

        public UsersRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public IEnumerable<UserDetailData> GetAll()
        {
            return _dbContext.UserDetailData;
        }

        public void Add(UserDetailData item)
        {
            item.UserId = Guid.NewGuid().ToString();
            _dbContext.UserDetailData.Add(item);
            _dbContext.SaveChanges();
        }

        public UserDetailData Get(string id)
        {
            UserDetailData item = _dbContext.UserDetailData.Find(id);
            //Users.TryGetValue(id, out UserDetailData item);
            return item;
        }

        public UserDetailData Remove(string id)
        {
            UserDetailData user = _dbContext.UserDetailData.Find(id);
            _dbContext.UserDetailData.Remove(user);
             //_dbContext.UserDetailData.Remove(Get(id));
            //Users.TryRemove(id, out UserDetailData item);
            //return item;
            _dbContext.SaveChanges();
            return user;
            //return t;

        }

        public void Update(UserDetailData item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
