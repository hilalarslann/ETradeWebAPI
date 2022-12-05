using ETrade.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class BaseDescription : IBaseTable, IBaseDescription
    {
        public int Id { get; set; }
        //Returns the number of characters in a string.
        [StringLength(50)]
        public string Description { get; set; }
    }
}
