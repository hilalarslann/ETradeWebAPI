using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        IUoW _uow;
        Response _response;

        public UnitController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }
        public List<Unit> ListUnit()
        {
            return _uow._UnitRep.ListUnit();
        }

        [HttpPost]
        public Response AddUnit(Unit unit)
        {
            try
            {
                _uow._UnitRep.Add(unit);
                _response.Error = false;
                _response.Msg = "Birim eklendi";
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
        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            var category = _uow._UnitRep.Get(x => x.Id == id);
            if (category is null)
                return BadRequest("The unit that you want to delete is not available in DataBase");

            _uow._UnitRep.Delete(id);
            _uow.Commit();

            return Ok("Unit Deleted");
        }
    }
}
