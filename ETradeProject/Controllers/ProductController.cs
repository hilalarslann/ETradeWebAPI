using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public ProductController(IUoW uow, Response response)
        {
            //test
            _uow = uow;
            _response = response;
        }

        [HttpGet]
        public List<ProductDTO> ProductList()
        {
            return _uow._ProductRep.ListProduct();
        }

        [HttpPost]
        public Response AddProduct(ProductModel productModel)
        {
            try
            {
                var product = _uow._ProductRep.AddProduct(productModel);
                _uow._ProductRep.Add(product);
                _response.Error = false;
                _response.Msg = "Başarılı eklendi";
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;

                throw;
            }

            return _response;
        }

        [HttpGet("{id}")]
        public ProductDTO GetById(int id)
        {
            return _uow._ProductRep.GetById(id);
        }

        [HttpDelete("{id}")]
        public Response DeleteProduct(int id)
        {
            try
            {
                _uow._ProductRep.Delete(id);
                _response.Error = false;
                _response.Msg = "Başarı ile silindi";
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _response.Error = false;
                _response.Msg = ex.Message;
                throw;
            }

            return _response;
        }

        [HttpPut("{id}")]
        public Response Update(int id, ProductModel pModel)
        {
            try
            {
                _uow._ProductRep.Put(id, pModel);
                _uow.Commit();
                _response.Error = false;
                _response.Msg = "Güncellendi";
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;
                throw;
            }

            return _response;
        }
    }
}
