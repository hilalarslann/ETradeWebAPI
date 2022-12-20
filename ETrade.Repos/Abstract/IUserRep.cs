using ETrade.Core;
using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstract
{
    public interface IUserRep : IBaseRepository<User>
    {
        UserDTO CreateUser(UserDTO user);
        UserDTO Login(string Mail, string Password);
    }
}
