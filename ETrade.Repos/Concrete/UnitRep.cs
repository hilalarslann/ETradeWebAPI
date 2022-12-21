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
    public class UnitRep<T> : BaseRepository<Unit>, IUnitRep where T : class
    {
        public UnitRep(ETradeContext db) : base(db)
        {

        }
        public Unit AddUnit(Unit unit)
        {
            Unit p = new Unit();
            p.Id = unit.Id;
            p.Description = unit.Description;
            return p;

        }

        public List<Unit> ListUnit()
        {
            return Set().Select(x => new Unit
            {
                Id = x.Id,
                Description = x.Description,
            }).ToList();
        }
    }
}
