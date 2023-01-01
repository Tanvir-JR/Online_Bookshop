using BLL.DTOs;
using BLL.Services;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Online_Bookshop.Controllers
{
    public class BookStoreController: ApiController
    {
        [Route ("api/bookstores")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = BookStoreService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bookstores/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = BookStoreService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/bookstores/add")]
        [HttpPost]

        public HttpResponseMessage Post(BookStoreDTO book)
        {
            var resp = BookStoreService.Add(book);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = book });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
        [Route("api/bookstores/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = BookStoreService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "DELETED");
        }

        [Route("api/bookstores/update")]
        [HttpPost]
        public HttpResponseMessage Update(BookStore s)
        {
            BookStoreService.Update(s);
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
    }
}