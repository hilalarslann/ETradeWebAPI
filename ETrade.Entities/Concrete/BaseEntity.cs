using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class BaseEntity : IBaseTable, IAddress
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? Avenue { get; set; }
        public int? No { get; set; }
        public int? CountyId { get; set; }
    }
    //veritipi değişmini nasıl yaparız migrationı silmeden 
}
