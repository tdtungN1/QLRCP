using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers
{
    public class GenreRoomController : ApiController
    {
        // GET: api/GenreRoom
        public IEnumerable<Genre_room> Get()
        {
            List<Genre_room> genre_room = new List<Genre_room>();
            string query = "SELECT * FROM dbo.Genre_room";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Genre_room item = new Genre_room();
                item.GenreRoomID = int.Parse(row["GenreRoomID"].ToString());
                item.GenreRoomName = row["GenreRoomName"].ToString();
                genre_room.Add(item);
            }
            return genre_room;
        }

        // GET: api/GenreRoom/5
        public Genre_room Get(int id)
        {
            string query = "SELECT * FROM dbo.Genre_room WHERE GenreRoomID = " + id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Genre_room genre_Room = new Genre_room();
            genre_Room.GenreRoomID = int.Parse(table.Rows[0]["GenreRoomID"].ToString());
            genre_Room.GenreRoomName = table.Rows[0]["GenreRoomName"].ToString();
            return genre_Room;
        }

        // POST: api/GenreRoom
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GenreRoom/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GenreRoom/5
        public void Delete(int id)
        {
        }
    }
}
