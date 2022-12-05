using ETrade.Entities.Concrete;
using ETrade.UI.Models;
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
        UserModel _userModel;
        Response _response;
        public AuthController(IUoW uow, UserModel userModel)
        {
            _uow = uow;
            _userModel = userModel;
        }

        //[HttpGet]
        //public JsonResult Register()
        //{
        //    _userModel.User = new User();
        //    _userModel.Counties = _uow._CountyRep.List();
        //    return new JsonResult(_userModel);
        //}

        [HttpPost]
        public Response Register(User user)
        {
            _uow._UserRep.CreateUser(user);
            try
            {
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return _response;
        }

    }
}
