using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public BrandController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }
        [HttpGet]
        public List<Brand> ListBrand()
        {
            return _uow._BrandRep.List();
        }
        [HttpPost]
        public Response AddBrand(Brand brand)
        {
            try
            {
                _uow._BrandRep.Add(brand);
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
        public Response DeleteBrand(int id)
        {
            try
            {
                _uow._BrandRep.Delete(id);
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
