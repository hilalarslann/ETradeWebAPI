using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.DTO.Models
{
    public class BasketDetailModel
    {
        public List<ProductDTO>? ProductDTOs { get; set; }
        public List<BasketDetailDTO>? BasketDetailDTOs { get; set; }
        public decimal? UnitPrice { get; set; }
        public int ProductId { get; set; }
        //Amount - Adet
        public int Amount { get; set; }
        //Ratio - Kdv oranı
        public decimal? Ratio { get; set; }
        public int? UnitId { get; set; }
    }
}
