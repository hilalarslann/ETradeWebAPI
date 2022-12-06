using ETrade.Core;
using ETrade.Dal;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concrete
{
    public class UserRep<T> : BaseRepository<User>, IUserRep where T : class
    {
        ETradeContext _db;
        public UserRep(ETradeContext db) : base(db)
        {
            _db = db;
        }
        public User CreateUser(User user)
        {
            User selectedUser = Get(x => x.Mail == user.Mail);
            if (selectedUser == null)
                user.Error = false;
            else
                user.Error = true;

            // CheckPassword(user.Password); 

            if (user.Password.Length >= 8 && (user.Password.Length <= 14))
            {

            }
            else
            {
                string passMsg = "Şifreniz....";
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "User";
            return user;
        }

        public void CheckPassword(string password)
        {
            if (password.Length >= 8 && (password.Length <= 14))
            {

            }
            else
            {
                Console.WriteLine("sdfdf");
            }





        }

    }
}
