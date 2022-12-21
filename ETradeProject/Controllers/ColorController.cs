using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public ColorController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet]
        public List<Color> ListColor()
        {
            return _uow._ColorRep.List();
        }
        [HttpPost]
        public Response AddColor(Color color)
        {
            try
            {
                _uow._ColorRep.Add(color);
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
        public Response DeleteColor(int id)
        {
            try
            {
                _uow._ColorRep.Delete(id);
                _response.Error=false;
                _response.Msg = "Başarı İle Silindi.";
                _uow.Commit();
                
            }
            catch (Exception ex)
            {
                _response.Error = false;
                _response.Msg = ex.Message;
            }
            return _response;
        }
    }
}
