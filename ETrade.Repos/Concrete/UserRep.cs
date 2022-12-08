using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
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
        //public User CreateUser(User user)
        //{
        //    User selectedUser = Get(x => x.Mail == user.Mail);
        //    if (selectedUser == null)
        //        user.Error = false;
        //    else
        //        user.Error = true;

        //    CheckPassword(user);

        //    user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        //    user.Role = "User";
        //    return user;
        //}
        //public void CheckPassword(User user)
        //{
        //    if ((user.Password.Length >= 8) && (user.Password.Length <= 14) && (user.Password.Any(char.IsLower)) && (user.Password.Any(char.IsUpper)))
        //    {
        //        user.CheckPassword = true;
        //    }
        //    else if (user.Password.Contains(" "))
        //    {
        //        user.CheckPassword = false;
        //    }
        //    else
        //    {
        //        user.CheckPassword = false;
        //    }
        //}

        public BaseMethodResult CreateUser(UserDTO user)
        {
            BaseMethodResult result = new BaseMethodResult();
            User selectedUser = Get(x => x.Mail == user.Mail);
            if (selectedUser != null)
            {
                result.IsSucceed = false;
                result.Msg = "mail mevcut";
                return result;
            }

            result = CheckPassword(user);
            if (!result.IsSucceed)
            {
                return result;
            }

            var newUser = new User()
            {
                Id = user.Id,
                Mail = user.Mail,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Role = "User"
            };
            Add(newUser);
            result.IsSucceed = Add(newUser);
            if (!result.IsSucceed)
            {
                result.Msg = "kaydelimedei";
                return result;
            }
            result.Msg = "başarılı";
            return result;
        }
        public BaseMethodResult CheckPassword(UserDTO user)
        {
            BaseMethodResult result = new BaseMethodResult();

            if ((user.Password.Length >= 8) && (user.Password.Length <= 14) && (user.Password.Any(char.IsLower)) && (user.Password.Any(char.IsUpper)))
            {
                if (user.Password.Contains(" "))
                {
                    result.IsSucceed = false;
                    result.Msg = "boşluk içermemelidir";
                    return result;
                }
                else
                {
                    result.IsSucceed = true;
                }
            }
            else
            {
                result.IsSucceed = false;
                result.Msg = "14 karakter";
                return result;
            }
            if (user.Password != user.RePassword)
            {
                result.IsSucceed = false;
                result.Msg = "şifreler aynı değil";
                return result;
            }
            return result;
        }

    }
}
