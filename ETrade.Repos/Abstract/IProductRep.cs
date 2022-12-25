using ETrade.Core;
using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETrade.Repos.Abstract
{
    public interface IProductRep : IBaseRepository<Product>
    {
        List<ProductDTO> ListProduct();
        public Product AddProduct(ProductModel productModel);
        public ProductDTO GetById(int id);
        public void Put(int id, ProductModel productModel);
        public Product FindWithVat(int Id);
    }
}
