using ETrade.Core;
using ETrade.DTO;
using ETrade.Entities;
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
    public class AuthController : ControllerBase
    {
        IUoW _uow;
        Response _response;
        public AuthController(IUoW uow, Response response)
        {
            _uow = uow;
            _response = response;
        }

        [HttpPost]
        public Response Register(UserDTO user)
        {
            user = _uow._UserRep.CreateUser(user);
            try
            {
                if (user.Error)
                {
                    _response.Error = true;
                    _response.Msg = user.Msg;
                }
                else
                {
                    _uow._UserRep.Add(user.Map());
                    var x = user.Map(); ;
                    _uow.Commit();
                    _response.Error = false;
                    _response.Msg = "Kaydınız Başarıyla Eklendi";
                    return _response;
                }
            }
            catch (Exception ex)
            {
                _response.Msg = ex.Message;
                _response.Error = true;
            }

            return (_response);
        }

        [HttpPost]
        public Response Login(UserDTO userDto)
        {
            UserDTO user = _uow._UserRep.Login(userDto.Mail, userDto.Password);

            if (user.Error == false)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));

                if (user.Role == "Admin")
                {
                    _response.Error = false;
                    _response.Msg = "Admin girişi başarılı";
                }
                else
                {
                    _response.Error = false;
                    _response.Msg = "User girişi başarılı";
                }
            }
            else
            {
                user.Msg = "Yanlış giriş";
                _response.Error = true;
                _response.Msg = user.Msg;
            }

            return _response;
        }
        [HttpPost]
        public Response Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                _response.Error = false;
                _response.Msg = "Çıkış Yapıldı";
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
