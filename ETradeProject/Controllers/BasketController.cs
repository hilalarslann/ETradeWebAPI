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
    public class BasketController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        BasketMaster _basketMaster;
        BasketDetail _basketDetail;
        public BasketController(IUoW uow, Response response, BasketMaster basketMaster)
        {
            _uow = uow;
            _response = response;
            _basketMaster = basketMaster;
        }


        [HttpGet]
        public List<BasketDetailDTO> BasketList()
        {
            var usr = _uow._UserRep.Find(1);

            var selectedBasket = _uow._BasketMasterRep.Get(x => x.Completed == false && x.UserId == usr.Id);

            if (selectedBasket != null)
            {
                return _uow._BasketDetailRep.BasketDetailDTOs(selectedBasket.Id);
            }

            else
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.UserId = usr.Id;
                _uow._BasketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return _uow._BasketDetailRep.BasketDetailDTOs(_basketMaster.Id);
            }
        }

        [HttpPost]
        public Response AddBasket(int id)
        {

        }




        //[HttpGet]
        //public List<BasketDetailDTO> BasketDetailList()
        //{
        //    return _uow._BasketDetailRep.BasketDetailDTOs();
        //}


    }
}

