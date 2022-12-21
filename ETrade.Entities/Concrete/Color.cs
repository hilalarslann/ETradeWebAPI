using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class Color:BaseDescription
    {
        public ICollection<Product> ?Products { get; set; }
    }
}
