using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{

    [Route("/[controller]/[action]")]
    [ApiController]
    public class VatController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public VatController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet]
        public List<Vat> ListVat()
        {
            return _uow._VatRep.List();
        }
        [HttpPost]
        public Response AddVat(Vat vat)
        {
            try
            {
                _uow._VatRep.Add(vat);
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
        public Response DeleteVat(int id)
        {
            try
            {
                _uow._VatRep.Delete(id);
                _response.Error = false;
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
