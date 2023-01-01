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
    public class PaymentController : ApiController
    {
        // GET: Payment
        [Route("api/payments")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PaymentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/payments/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = PaymentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/payments/add")]
        [HttpPost]

        public HttpResponseMessage Post(PaymentDTO payment)
        {
            var resp = PaymentService.Add(payment);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = payment });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        [Route("api/payments/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = PaymentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
        [Route("api/payments/update")]
        [HttpPost]
        public HttpResponseMessage Update(Payment s)
        {
            PaymentService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}