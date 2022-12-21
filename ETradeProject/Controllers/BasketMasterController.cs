using ETrade.DTO;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class BasketMasterController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        BasketMaster _basketmaster;
        public BasketMasterController(IUoW uow, Response response, BasketMaster basketMaster)
        {
            _uow = uow;
            _response = response;
            _basketmaster = basketMaster;
        }
        [HttpPost]
        public Response Create()
        {
            var usr = JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedBasket = _uow._BasketMasterRep.Set().FirstOrDefault(x => x.Completed == false && x.EntityId == usr.Id);
            try
            {
                if (selectedBasket != null)
                {
                    _response.Error = true;
                    _response.Msg = "Zaten mevcut Sepetiniz Var";
                    return _response;
                }
                //burada geri döndürürken id=selectedbasket.Id ye eşitlenmiş ama bi burada yapmadık.
                else
                {
                    _basketmaster.OrderDate = DateTime.Now;
                    _basketmaster.EntityId = usr.Id;
                    _uow._BasketMasterRep.Add(_basketmaster);
                    _uow.Commit();
                    _response.Error = false;
                    _response.Msg = "Yeni Sepetiniz Oluşturuldu.";
                }

            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;
            }
            return _response;
        }
        
    }
}
