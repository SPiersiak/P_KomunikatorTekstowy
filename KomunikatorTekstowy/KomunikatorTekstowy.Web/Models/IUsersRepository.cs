using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomunikatorTekstowy.Web.Models
{
    public interface IUsersRepository
    {
        void Add(UserDetailData item);
        //void Update(UserDetailData item, string id);
        UserDetailData Remove(string key);
        UserDetailData Get(string id);
        IEnumerable<UserDetailData> GetAll();
        void Update(UserDetailData item);
    }
}
