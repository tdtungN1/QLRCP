using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public int Post([FromBody]Genre_room value)
        {
            string query = "INSERT dbo.Genre_room(GenreRoomName)VALUES(N'" + value.GenreRoomName+ "')";
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

        // PUT: api/GenreRoom/5
        public int Put(int id, [FromBody]Genre_room value)
        {
            string query = "UPDATE dbo.Genre_room SET GenreRoomName = N'" + value.GenreRoomName + "' WHERE GenreRoomID = "+id;
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

        // DELETE: api/GenreRoom/5
        public int Delete(int id)
        {
            string query = "DELETE  dbo.Genre_room WHERE GenreRoomID = " + id;
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
