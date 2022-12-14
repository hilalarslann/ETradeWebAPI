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
                _uow._ProductRep.Add(_uow._ProductRep.AddProduct(productModel));
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
    }
}
