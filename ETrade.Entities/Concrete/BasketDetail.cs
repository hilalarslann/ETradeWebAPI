using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class BasketDetail : IBaseTable 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int UnitId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public int Ratio { get; set; }
        [ForeignKey("OrderId")]
        public BasketMaster BasketMaster { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

    }
}
