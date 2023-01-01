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
    public class ReportController : ApiController
    {
        // GET:Report
        [Route("api/reports")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = ReportService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/reports/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = ReportService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/reports/add")]
        [HttpPost]

        public HttpResponseMessage Post(ReportDTO report)
        {
            var resp = ReportService.Add(report);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = report });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
        [Route("api/reports/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = ReportService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
        [Route("api/reports/update")]
        [HttpPost]
        public HttpResponseMessage Update(Report s)
        {
            ReportService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }


    }
}