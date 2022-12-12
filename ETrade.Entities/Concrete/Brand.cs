using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class Brand : BaseDescription,IBaseTable
    {
        public int Id { get; set; }

    }
}
