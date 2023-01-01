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
    public class CategoryController : ApiController
    {
        [Route("api/categories")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/categories/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/categories/{id}/books")]
        [HttpGet]
        public HttpResponseMessage GetCtBook(int id)
        {
            try
            {
                var data = CategoryService.GetwithBooks(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [Route("api/categories/add")]
        [HttpPost]
        public HttpResponseMessage Add(CategoryDTO ct)
        {
            try
            {
                var data = CategoryService.Add(ct);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
