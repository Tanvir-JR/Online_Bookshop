using BLL.DTOs;
using BLL.Services;
using DAL.EF;
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
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Post(UserDTO user)
        {
            var resp = UserService.Add(user);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = user });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/user/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

        [Route("api/user/update")]
        [HttpPost]
        public HttpResponseMessage Update(User s)
        {
            UserService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }

       /* [Route("api/users/search/{name}")]
        [HttpGet]
        public HttpResponseMessage Search(string name)
        {
            var data = UserService.Search(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }*/
    }
}
