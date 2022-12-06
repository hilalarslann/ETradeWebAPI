using ETrade.Entities.Concrete;
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
        public AuthController(IUoW uow)
        {
            _uow = uow;
        }

        //[HttpGet]
        //public JsonResult Register()
        //{
        //    _userModel.User = new User();
        //    _userModel.Counties = _uow._CountyRep.List();
        //    return new JsonResult(_userModel);
        //}

        [HttpPost]
        public JsonResult Register(User user)
        {
            string msg;
            user = _uow._UserRep.CreateUser(user);
            try
            {
                if (!user.Error)
                {
                    _uow._UserRep.Add(user);
                    _uow.Commit();
                    user.Error = false;
                    msg = "Başarıyla eklenmiştir.";
                }
                else
                {
                    user.Error = true;
                    msg = $"{user.Mail} zaten mevcut";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                throw;
            }
            return new JsonResult(msg)
            {
                Value = msg,
                ContentType = "charset=UTF-8"
            };
        }

    }
}
