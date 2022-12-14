using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Entities.Concrete
{
    public class Product : BaseDescription
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public int SubCatId { get; set; }
        public int SizeId { get; set; }
        public int UnitId { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public int VatId { get; set; }
        [ForeignKey("VatId")]
        public Vat Vats { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("SizeId")]
        public Size Size { get; set; }

        [ForeignKey("SubCatId")]
        public SubCategory SubCategory { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }
        public ICollection<BasketDetail> BasketDetails { get; set; }

    }
}
