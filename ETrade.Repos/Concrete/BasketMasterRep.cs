using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concrete
{
    public class BasketMasterRep<T> : BaseRepository<BasketMaster>, IBasketMasterRep where T : class
    {
        public BasketMasterRep(ETradeContext db) : base(db)
        {

        }
    }
}
