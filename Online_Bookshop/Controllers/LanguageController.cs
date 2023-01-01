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
    public class LanguageController : ApiController
    {
        // GET: Language
        [Route("api/languages")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = LanguageService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/languages/{id}")]
        [HttpGet]

        public HttpResponseMessage Get(int id)
        {
            var data = LanguageService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/languages/add")]
        [HttpPost]

        public HttpResponseMessage Post(LanguageDTO language)
        {
            var resp = LanguageService.Add(language);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = language });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        [Route("api/languages/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = LanguageService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }
        [Route("api/languages/update")]
        [HttpPost]
        public HttpResponseMessage Update(Language s)
        {
            LanguageService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}
