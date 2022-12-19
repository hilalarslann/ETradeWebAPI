using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public CategoryController(Response response, IUoW uow)
        {
            _response = response;
            _uow = uow;
        }

        [HttpGet]
        public List<Category> ListCategory()
        {
            return _uow._CategoryRep.List();
        }


        [HttpGet("{id}")]
        public IActionResult GetByIdCategory(int id)
        {
            var category = _uow._CategoryRep.Get(x => x.Id == id);

            if (category is null)
            {
                return BadRequest("The category was not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public Response AddCategory(Category category)
        {
            try
            {
                _uow._CategoryRep.Add(category);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _uow._CategoryRep.Get(x => x.Id == id);
            if (category is null)
                return BadRequest("The category that you want to delete is not available in DataBase");

            _uow._CategoryRep.Delete(id);
            _uow.Commit();

            return Ok("Category Deleted");
        }
    }
}
