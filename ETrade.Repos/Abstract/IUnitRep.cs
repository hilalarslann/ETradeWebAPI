using ETrade.Core;
using ETrade.DTO;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstract
{
    public interface IUnitRep : IBaseRepository<Unit>
    {
        public List<Unit> ListUnit();
        public Unit AddUnit(Unit unit);
    }
}
