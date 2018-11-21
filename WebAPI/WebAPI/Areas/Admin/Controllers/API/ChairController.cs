using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers.API
{
    public class ChairController : ApiController
    {
        // GET: api/Chair
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Chair/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Chair
        public void Post([FromBody]Chair value)
        {
            
        }

        // PUT: api/Chair/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chair/5
        public void Delete(int id)
        {
        }
    }
}
