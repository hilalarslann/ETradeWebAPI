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

        public int UserBasketMaster()
        {
            var usr = _uow._UserRep.Find(1);
            var selectedBasket = _uow._BasketMasterRep.Get(x => x.Completed == false && x.UserId == usr.Id);

            if (selectedBasket != null)
                return (selectedBasket.Id);
            else
            {
                _basketMaster.OrderDate = DateTime.Now;
                _basketMaster.UserId = usr.Id;
                _uow._BasketMasterRep.Add(_basketMaster);
                _uow.Commit();
                return (_basketMaster.Id);
            }
        }

        [HttpGet]
        public List<BasketDetailDTO> BasketList()
        {
            return _uow._BasketDetailRep.BasketDetailDTOs(UserBasketMaster());
        }

        [HttpPost]
        public Response AddBasket(BasketDetailModel bdModel)
        {
            Product product = _uow._ProductRep.FindWithVat(bdModel.ProductId);
            var usrBasketDetail = new BasketDetail();

            if (_uow._BasketDetailRep.CheckProductBasket(bdModel.ProductId) == false)
            {
                usrBasketDetail.Id = UserBasketMaster();
                usrBasketDetail.ProductId = product.Id;
                usrBasketDetail.UnitId = product.UnitId;
                usrBasketDetail.Amount = bdModel.Amount;
                usrBasketDetail.UnitPrice = product.UnitPrice;
                usrBasketDetail.Ratio = product.Vats.Ratio;
                usrBasketDetail.BasketMasterId = UserBasketMaster();
                _uow._BasketDetailRep.Add(usrBasketDetail);
            }

            _uow.Commit();
            return _response;
        }
    }
}

