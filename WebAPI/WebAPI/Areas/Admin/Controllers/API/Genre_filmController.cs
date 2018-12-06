using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers.API
{
    public class Genre_filmController : ApiController
    {
        // GET: api/Genre_film
        public IEnumerable<Genre_film> Get()
        {
            List<Genre_film> genre_Films = new List<Genre_film>();
            string query = "SELECT * FROM dbo.Genre_film";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Genre_film item = new Genre_film();
                item.GenreFilmID = int.Parse(row["GenreFilmID"].ToString());
                item.GenreFilmName = row["GenreFilmName"].ToString();
                genre_Films.Add(item);
            }
            return genre_Films;
        }

        // GET: api/Genre_film/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Genre_film
        public int Post([FromBody]Genre_film value)
        {
            string query = "INSERT dbo.Genre_film(GenreFilmName)VALUES(N'" + value.GenreFilmName + "')";
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException)
            {
                return 0;
            }
            return 1;
        }

        // PUT: api/Genre_film/5
        public int Put(int id, [FromBody]Genre_film value)
        {
            string query = "UPDATE dbo.Genre_film SET GenreFilmName = N'" + value.GenreFilmName + "' WHERE GenreFilmID = " + id;
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException)
            {
                return 0;
            }
            return 1;
        }

        // DELETE: api/Genre_film/5
        public int Delete(int id)
        {
            string query = "DELETE  dbo.Genre_film WHERE GenreFilmID = " + id;
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException)
            {
                return 0;
            }
            return 1;
        }
    }
}
