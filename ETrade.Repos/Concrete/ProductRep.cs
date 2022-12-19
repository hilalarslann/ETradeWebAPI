using ETrade.Core;
using ETrade.Dal;
using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using ETrade.Repos.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Concrete
{
    public class ProductRep<T> : BaseRepository<Product>, IProductRep where T : class
    {

        public ProductRep(ETradeContext db) : base(db)
        {

        }

        public List<ProductDTO> ListProduct()
        {
            return Set().Select(x => new ProductDTO
            {
                Id = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                Color = x.Color.Description,
                Size = x.Size.Description,
                Brand = x.Brand.Description,
                Category = x.SubCategory.Category.Description,
                SubCategory = x.SubCategory.Description,
                Unit = x.Unit.Description,
                Ratio = x.Vats.Ratio,
                Amount=x.Amount,
                Total = (x.UnitPrice * x.Amount) * (1 + x.Vats.Ratio / 100),

            }).ToList();
        }
        public Product AddProduct(ProductModel productModel)
        {
            Product p = new Product();
            p.ProductName = productModel.ProductName;
            p.UnitPrice = productModel.UnitPrice;
            p.Amount = productModel.Amount;
            p.ColorId = productModel.ColorId;
            p.SizeId = productModel.SizeId;
            p.BrandId = productModel.BrandId;
            p.SubCatId = productModel.SubCategoryId;
            p.UnitId = productModel.UnitId;
            p.VatId = productModel.VatId;

            //Yeni ürün eklediğinde var olan üründen varsa ne yapılmalı
            //Varsa olan ürünün adeti arttırılıp tekrar veritabanına eklenmemeli.

            return p;
        }

        public ProductDTO GetById(int id)
        {
            var product = ListProduct().Where(x => x.Id == id).SingleOrDefault(); 
            return product;
        }
    }
}
