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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _uow._ProductRep.GetById(id);

            if (product is null)
            {
                return BadRequest("The product was not found");
            }

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _uow._ProductRep.GetById(id);
            if (product is null)
                return BadRequest("The Product that you want to delete is not available in DataBase");

            _uow._ProductRep.Delete(id);
            _uow.Commit();

            return Ok("Product Deleted");
        }
    }
}
