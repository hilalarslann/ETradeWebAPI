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
    public class ProductRep<T> : BaseRepository<Product>, IProductRep where T : class
    {
        public ProductRep(ETradeContext db) : base(db)
        {

        }
    }
}
