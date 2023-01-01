using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Online_Bookshop.Controllers
{

    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(UserDTO login)
        {
            var data = AuthService.Authenticate(login.username, login.password);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/logout")]
        [HttpPost]
        public HttpResponseMessage Logout(UserDTO login)
        {
            var data = AuthService.Logout(login.username, login.password);
            if (data != null)
            {
                
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
