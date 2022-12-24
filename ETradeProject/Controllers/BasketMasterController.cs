using ETrade.Dal;
using ETrade.Dal.Migrations;
using ETrade.DTO;
using ETrade.DTO.Models;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ETrade.UI.Controllers
{

    [Route("/[controller]/[action]")]
    [ApiController]
    public class BasketMasterController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        BasketMaster _basketmaster;
        BasketDetail _basketDetail;
        BasketDetailModel _detailModel;
        ETradeContext _etradeContext;
        //BasketMaster selectedBasket;
        public BasketMasterController(IUoW uow, Response response, BasketMaster basketMaster, BasketDetail basketDetail, BasketDetailModel detailModel, ETradeContext etradeContext)
        {
            _uow = uow;
            _response = response;
            _basketmaster = basketMaster;
            _etradeContext = etradeContext;
            _detailModel = detailModel;
        }
        [HttpPost]
        public Response Create()
        {
            var usr = _uow._UserRep.Find(2);
            //JsonConvert.DeserializeObject<UserDTO>(HttpContext.Session.GetString("User"));
            var selectedBasket = _uow._BasketMasterRep.Get(x => x.Completed == false && x.UserId == usr.Id);

            try
            {
                if (selectedBasket != null)
                {
                    _response.Error = true;
                    _response.Msg = "Zaten mevcut Sepetiniz Var";
                    // AddBasket(model, selectedBasket.Id);
                }
                //burada geri döndürürken id=selectedbasket.Id ye eşitlenmiş ama bi burada yapmadık.
                else
                {
                    _basketmaster.OrderDate = DateTime.Now;
                    _basketmaster.UserId = usr.Id;
                    _uow._BasketMasterRep.Add(_basketmaster);
                    _uow.Commit();
                    _response.Error = false;
                    _response.Msg = "Başarılı";
                    //AddBasket(model, _basketmaster.Id);
                }
            }
            catch (Exception ex)
            {
                _response.Error = true;
                _response.Msg = ex.Message;
            }
            return _response;
        }

        //[HttpGet]
        //public List<BasketDetailDTO> BasketDetailList()
        //{
        //    return _uow._BasketDetailRep.ListBasketDetail();
        //}



        //[HttpPost]
        //public Response AddBasket(int id)
        //{
        //    _detailModel.BasketDetailDTOs = _uow._BasketDetailRep.BasketDetailDTOs(id);

        //    return _response;
        //}

        //[HttpPost]
        //public Response AddBasket(BasketDetailModel m, int id)
        //{
        //    _detailModel.BasketDetailDTOs = _uow._BasketDetailRep.BasketDetailDTOs(id);

        //    Product product = new Product();
        //    _basketDetail.Amount = m.Amount;
        //    _basketDetail.ProductId = m.ProductId;
        //    _basketDetail.Id = id;
        //    _basketDetail.UnitId = product.UnitId;
        //    _basketDetail.UnitPrice = product.UnitPrice;
        //    _uow._BasketDetailRep.Add(_basketDetail);
        //    _uow.Commit();
        //    return _response;
        //}




        //[HttpPost]
        //public Response AddBasket(BasketDetailDTO basketDetailDTO)
        //{
        //    BasketMaster bm = new BasketMaster();
        //    BasketDetail bd = new BasketDetail();
        //    bd.Id = bm.Id;
        //    _etradeContext.SaveChanges();
        //    try
        //    {
        //        basketDetailDTO.Id = bd.Id;
        //        bd.Product.ProductName = basketDetailDTO.Name;
        //        bd.Product.Brand.Description = basketDetailDTO.Brand;
        //        bd.Product.Amount = basketDetailDTO.Amount;
        //        basketDetailDTO.Total = (bd.Product.UnitPrice * bd.Product.Amount) * (1 + bd.Product.Vats.Ratio);
        //        _uow._BasketDetailRep.Add(bd);
        //        _response.Error = false;
        //        _response.Msg = "Başarılı eklendi";
        //        _uow.Commit();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return _response;
        //}
    }
}
