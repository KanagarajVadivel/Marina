using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marina.Web.Controllers
{
    [RoutePrefix("api/User")]
    [Authorize]
    public class UserController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            return System.Web.HttpContext.Current.User.Identity.Name;
        }        
    }
}