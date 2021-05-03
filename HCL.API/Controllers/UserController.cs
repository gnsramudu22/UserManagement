using HCL.BL;
using HCL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCL.API.Controllers
{
    public class UserController : ApiController
    {

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetAll()
        {
            using(UserManager mgr = new UserManager())
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, mgr.GetAll());
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        [HttpGet]
        [Route("user/{userId}")]
        public HttpResponseMessage GetByUserID(string userId)
        {
            using (UserManager mgr = new UserManager())
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, mgr.GetByID(userId));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        [HttpPost]
        [Route("user/save")]
        public HttpResponseMessage Save(User newObj)
        {
            using (UserManager mgr = new UserManager())
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, mgr.Save(newObj));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        [HttpPost]
        [Route("user/update")]
        public HttpResponseMessage Update(User modObj)
        {
            using (UserManager mgr = new UserManager())
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, mgr.Update(modObj));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }


        [HttpDelete]
        [Route("user/{userId}")]
        public HttpResponseMessage Delete(string userId)
        {
            using (UserManager mgr = new UserManager())
            {
                try
                {
                    return Request.CreateResponse(HttpStatusCode.OK, mgr.Delete(userId));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }
    }
}
