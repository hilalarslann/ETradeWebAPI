using ETrade.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ETrade.UoW
{
    public interface IUoW
    {
        IBasketDetailRep _BasketDetailRep { get; }
        IBasketMasterRep _BasketMasterRep { get; }
        ICategoryRep _CategoryRep { get; }   
        ICityRep _CityRep { get; }
        ICountyRep _CountyRep { get; }
        IProductRep _ProductRep { get; }
        IUnitRep _UnitRep { get; }
        IUserRep _UserRep { get; }
        IVatRep _VatRep { get; }
        void Commit();

    }
}
