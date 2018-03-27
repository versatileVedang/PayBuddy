using PayBuddy.Domain.AppUow.Interface;
using PayBuddy.Infrastructure.UnitofWork.Interface;
using PayBuddy.Models;
using PayBuddy.Web.Models.CustomModels;
using System.Linq;
using System.Web.Http;

namespace PayBuddy.Web.Controllers.api
{
    public class UserAuthenticationController : ApiBaseController
    {
        public UserAuthenticationController(IUow uow, IAppUow appUow)
        {
            Uow = uow;
            AppUow = appUow;
        }

        [HttpPost]
        [ActionName("postLogin")]
        public IHttpActionResult PostLogin(LoginModel user)
        {
            if (user.email != null && user.password != null)
            {
                var data = Uow.Repository<User>().FirstOrDefault(c => c.Email == user.email);
                if (data != null)
                {
                    byte[] userPassword = AppUow.PasswordEncryption.Encrypt(user.password, data.Salt);
                    if (AppUow.PasswordEncryption.VerifyPassword(data.Password, userPassword))
                    {
                        return Ok(new { data = data, message = true });
                    }
                    else
                    {
                        return Ok(4);
                    }
                }
                else
                {
                    return Ok(5);
                }

            }
            else
            {
                return Ok("Please Enter Your Email and Password");
            }
        }
    }
}
