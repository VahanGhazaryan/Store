using Common;
using Store.DAL.Abstract;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Concrete
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository() : base()
        {

        }
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;
            var hashPassword = Helper.HashSha256(password);
            var result = Find<User>(u => u.UserId == username && u.Password == hashPassword);
            if (result == null)
                return false;
            return true;
        }

        public bool Logout()
        {
            return true;
        }

        public void SaveChnages()
        {
            db.SaveChanges();
        }
    }
}
