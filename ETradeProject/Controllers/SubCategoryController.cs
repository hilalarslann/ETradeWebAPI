using ETrade.DTO;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public SubCategoryController(Response response, IUoW uow)
        {
            _response = response;
            _uow = uow;
        }

        [HttpGet]
        public List<SubCategoryDTO> ListSubCategory()
        {
            return _uow._SubCategoryRep.ListSubCategory();
        }

        //[HttpPost]
        //public IActionResult Add(SubCategory subCategory)
        //{
        //    var product = _uow._SubCategoryRep.Find(subCategory);
        //    if (product is not null)
        //        return BadRequest("Product is already available");

        //    _uow._SubCategoryRep.Add(subCategory);

        //    return Ok("Product Added");
        //}

        [HttpPost]
        public Response AddSubCategory(SubCategory subCategory)
        {
            try
            {
                _uow._SubCategoryRep.Add(subCategory);
                _response.Error = false;
                _response.Msg = "Başarı ile eklendi";
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
    }
}
