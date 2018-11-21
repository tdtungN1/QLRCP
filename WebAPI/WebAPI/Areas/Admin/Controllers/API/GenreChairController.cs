using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers.API
{
    public class GenreChairController : ApiController
    {
        // GET: api/GenreChair
        public IEnumerable<Genre_chair> Get()
        {
            List<Genre_chair> genre_chair = new List<Genre_chair>();
            string query = "SELECT * FROM dbo.Genre_chair";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Genre_chair item = new Genre_chair();
                item.GenreChairID = int.Parse(row["GenreChairID"].ToString());
                item.GenreChairName = row["GenreChairName"].ToString();
                genre_chair.Add(item);
            }
            return genre_chair;
        }

        // GET: api/GenreChair/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GenreChair
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GenreChair/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GenreChair/5
        public void Delete(int id)
        {
        }
    }
}
