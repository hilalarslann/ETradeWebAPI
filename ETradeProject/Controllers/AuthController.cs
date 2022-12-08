using ETrade.Core;
using ETrade.DTO;
using ETrade.Entities;
using ETrade.Entities.Concrete;
using ETrade.UI.HttpResponse;
using ETrade.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public AuthController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }

        //[HttpPost]
        //public Response Register(User user)
        //{
        //    user = _uow._UserRep.CreateUser(user);
        //    try
        //    {
        //        if (!(user.Error) && (user.CheckPassword))
        //        {
        //            _uow._UserRep.Add(user);
        //            _uow.Commit();
        //            _response.Error = false;
        //            _response.Msg = "Başarıyla eklenmiştir.";
        //        }
        //        else if (!user.CheckPassword)
        //        {
        //            _response.Msg = $"Şifreniz en az 7 karakter ve en fazla 64 karakter olmalı, büyük ve küçük harf içermelidir.";
        //        }
        //        else
        //        {
        //            _response.Error = true;
        //            _response.Msg = $"{user.Mail} zaten mevcut";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.Msg = ex.Message;
        //        _response.Error = true;
        //    }
        //    return (_response);
        //}

        [HttpPost]
        public Response Register(UserDTO user)
        {
            BaseMethodResult result = _uow._UserRep.CreateUser(user);
            try
            {
                if (result.IsSucceed)
                {
                    if(_uow.Commit())
                    {
                        _response.Msg = result.Msg;
                        _response.Error = result.IsSucceed;
                    }
                    else
                    {
                        _response.Msg = "Kaydedilemedi";
                        _response.Error = result.IsSucceed;
                    }
                }
                else
                {
                    _response.Msg = result.Msg;
                    _response.Error = result.IsSucceed;
                }
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
                _response.Error = true;
            }
            return (_response);
        }
    }
}
