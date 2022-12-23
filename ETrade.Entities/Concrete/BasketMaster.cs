using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class BasketMaster : IBaseTable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Completed { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }

    }
}
