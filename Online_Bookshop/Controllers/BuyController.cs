using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using DAL.EF;

namespace Online_Bookshop.Controllers
{
    public class BuyController : ApiController
    {
        // GET: Buy
        [Route("api/buys")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BuyService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/buys/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = BuyService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/buys/add")]
        [HttpPost]

        public HttpResponseMessage Post(BuyDTO buy)
        {
            var resp = BuyService.Add(buy);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = buy });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        [Route("api/buys/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BuyService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

        [Route("api/buys/update")]
        [HttpPost]
        public HttpResponseMessage Update(Buy s)
        {
            BuyService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}