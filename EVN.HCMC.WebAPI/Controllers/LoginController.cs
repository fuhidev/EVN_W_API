using EVN.HCMC.WebAPI.App_Start;
using EVN.HCMC.WebAPI.DataProvider.Manager;
using EVN.HCMC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EVN.HCMC.WebAPI.Controllers
{
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {

        private AccountDB context = new AccountDB();

        [Route("")]
        public HttpResponseMessage Post([FromBody] LoginRequest login)
        {
            var loginResponse = new LoginResponse { };

            bool isUsernamePasswordValid = false;

            if (login != null)
            {
                try
                {
                    isUsernamePasswordValid = this.context.IsValid(login.Username, login.Password);
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                }
            }

            // if credentials are valid
            if (isUsernamePasswordValid)
            {
                var tokenValidator = new TokenValidationHandler();
                string token = tokenValidator.CreateToken(login.Username);
                //return the token
                return Request.CreateResponse(HttpStatusCode.OK, token);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Tài khoản hoặc mật khẩu không đúng");
            }
        }
    }
}
