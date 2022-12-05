using ETrade.Core;
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
        User CreateUser(User user);
    }
}
