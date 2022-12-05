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
    public class CityRep<T> : BaseRepository<City>, ICityRep where T : class
    {
        public CityRep(ETradeContext db) : base(db)
        {

        }
    }
}
