using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DTO.Models
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int BrandId { get; set; }
        public int SubCategoryId { get; set; }
        public int UnitId { get; set; }
        public int VatId { get; set; }

    }
}
