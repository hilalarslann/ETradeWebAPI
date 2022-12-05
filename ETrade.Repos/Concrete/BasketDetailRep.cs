using ETrade.Core;
using ETrade.Dal;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concrete
{
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {
        public BasketDetailRep(ETradeContext db) : base(db)
        {

        }
    }
}
