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
    public class BasketDetailRep<T> : BaseRepository<BasketDetail>, IBasketDetailRep where T : class
    {
        public BasketDetailRep(ETradeContext db) : base(db)
        {

        }
        public List<BasketDetailDTO> BasketDetailDTOs(int BasketMasterId)
        {
            return Set().Where(x => x.Id == BasketMasterId).Select(x => new BasketDetailDTO
            {
                Id = x.Id,
                ProductId = x.ProductId,
                Name = x.Product.ProductName,
                Brand = x.Product.Brand.Description,
                Amount = x.Amount,
                Total = (x.UnitPrice + x.Amount) * (1 + x.Ratio / 100),
            }).ToList();
        }
    }
}
