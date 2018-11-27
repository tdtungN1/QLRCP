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
        public Genre_chair Get(int id)
        {
            string query = "SELECT * from dbo.Genre_chair WHERE GenreChairID = " + id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Genre_chair genreChair = new Genre_chair();
            genreChair.GenreChairID = int.Parse(table.Rows[0]["GenreChairID"].ToString());
            genreChair.GenreChairName = table.Rows[0]["GenreChairName"].ToString();
            return genreChair;
        }

        // POST: api/GenreChair
        public int Post([FromBody]Genre_chair value)
        {
            string query = "INSERT dbo.Genre_chair(GenreChairName)VALUES (N'" + value.GenreChairName + ")";
            int table = DataProvider.Instace.ExecuteNonQuery(query);
            return
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
