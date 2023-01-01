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
    public class RoleController : ApiController
    {
        [Route("api/roles")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = RoleService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/roles/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = RoleService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/roles/add")]
        [HttpPost]
        public HttpResponseMessage Post(RoleDTO role)
        {
            var resp = RoleService.Add(role);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = role });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [Route("api/roles/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            var data = RoleService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

        [Route("api/roles/update")]
        [HttpPost]
        public HttpResponseMessage Update(Role s)
        {
            RoleService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}
