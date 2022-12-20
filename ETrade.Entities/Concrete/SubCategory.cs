using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class SubCategory : BaseDescription
    {
        //SubCategory de veritabanına aynı verinin girilmemesi için composite key yapılabilir.
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
