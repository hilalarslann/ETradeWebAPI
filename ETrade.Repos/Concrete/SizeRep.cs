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
    public class SizeRep<T> : BaseRepository<Size>, ISizeRep where T : class
    {
        public SizeRep(ETradeContext db) : base(db)
        {
        }
    }
}
