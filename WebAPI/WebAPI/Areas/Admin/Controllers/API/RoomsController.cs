using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers
{
    public class RoomsController : ApiController
    {
        // GET: api/Rooms
        public IEnumerable<Room> GetRooms()
        {
            List<Room> room = new List<Room>();
            string query = "SELECT r.* , gr.GenreRoomName FROM dbo.Room r JOIN  dbo.Genre_room gr ON gr.GenreRoomID = r.GenreRoomID";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Room item = new Room();
                item.RoomID = int.Parse(row["RoomID"].ToString());
                item.RoomName = row["RoomName"].ToString();
                item.StatusRoom = byte.Parse(row["StatusRoom"].ToString());
                item.GenreRoomID = int.Parse(row["GenreRoomID"].ToString());
                Genre_room genre_Room = new Genre_room();
                genre_Room.GenreRoomID = int.Parse(row["GenreRoomID"].ToString());
                genre_Room.GenreRoomName = row["GenreRoomName"].ToString();
                item.Genre_room = genre_Room;
                room.Add(item);
            }
            return room;
        }
        // GET: api/Rooms/5
        public Room Get(int id)
        {
            string query = "SELECT r.* , gr.GenreRoomName FROM dbo.Room r JOIN  dbo.Genre_room gr ON gr.GenreRoomID = r.GenreRoomID WHERE r.RoomID = "+id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Room room = new Room();
            room.RoomID = int.Parse(table.Rows[0]["RoomID"].ToString());
            room.RoomName = table.Rows[0]["RoomName"].ToString();
            room.StatusRoom = byte.Parse(table.Rows[0]["StatusRoom"].ToString());
            room.GenreRoomID = int.Parse(table.Rows[0]["GenreRoomID"].ToString());
            room.RoomID = int.Parse(table.Rows[0]["RoomID"].ToString());
            Genre_room genre_Room = new Genre_room(room.GenreRoomID, table.Rows[0]["GenreRoomName"].ToString());
            room.Genre_room = genre_Room;
            return room;
        }
        // POST: api/RoomAPI
        public void Post([FromBody]Room value)
        {

        }
        //
    }
}