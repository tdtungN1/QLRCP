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
    public class ShowTimeController : ApiController
    {
        // GET: api/ShowTime
        public IEnumerable<ShowTime> Get(int genreRoomID)
        {
            List<ShowTime> showTimes = new List<ShowTime>();
            string query = "SELECT s.*,f.FilmName,r.RoomName,gr.GenreRoomName FROM dbo.ShowTime s JOIN dbo.Film f ON f.FilmID = s.FilmID JOIN dbo.Room r ON s.RoomID = r.RoomID JOIN dbo.Genre_room gr ON gr.GenreRoomID = r.GenreRoomID WHERE f.Status = 1 ";
            if (genreRoomID > 0)
            {
                query += " AND r.GenreRoomID = " + genreRoomID;
            }
            query += "ORDER BY s.StartTime , r.GenreRoomID , f.FilmName";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                ShowTime item = new ShowTime();
                item.FilmID = int.Parse(row["FilmID"].ToString());
                item.RoomID = int.Parse(row["RoomID"].ToString());
                item.ShowTimeID = int.Parse(row["ShowTimeID"].ToString());
                item.StartTime = DateTime.Parse(row["StartTime"].ToString());
                Film film = new Film();
                film.FilmID = item.FilmID;
                film.FilmName = row["FilmName"].ToString();
                item.Film = film;
                Room room = new Room();
                room.RoomName = row["RoomName"].ToString();
                Genre_room genre_Room = new Genre_room();
                genre_Room.GenreRoomName = row["GenreRoomName"].ToString();
                room.Genre_room = genre_Room;
                item.Room = room;

                showTimes.Add(item);
            }
            return showTimes;
        }


        // POST: api/ShowTime
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ShowTime/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ShowTime/5
        public void Delete(int id)
        {
        }
    }
}
