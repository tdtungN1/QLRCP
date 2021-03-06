﻿using System;
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
            string query = "SELECT r.* , gr.GenreRoomName FROM dbo.Room r JOIN  dbo.Genre_room gr ON gr.GenreRoomID = r.GenreRoomID WHERE r.RoomID = " + id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Room room = new Room();
            room.RoomID = int.Parse(table.Rows[0]["RoomID"].ToString());
            room.RoomName = table.Rows[0]["RoomName"].ToString();
            room.StatusRoom = byte.Parse(table.Rows[0]["StatusRoom"].ToString());
            room.GenreRoomID = int.Parse(table.Rows[0]["GenreRoomID"].ToString());
            room.RoomID = int.Parse(table.Rows[0]["RoomID"].ToString());
            Genre_room genre_Room = new Genre_room();
            genre_Room.GenreRoomID = room.GenreRoomID;
            genre_Room.GenreRoomName = table.Rows[0]["GenreRoomName"].ToString();
            room.Genre_room = genre_Room;
            return room;
        }
        // POST: api/Rooms
        public int Post([FromBody]Room value)
        {
            string query = "INSERT dbo.Room(RoomName,GenreRoomID,StatusRoom,NumRow,NumCol)VALUES(N'" + value.RoomName + "'," + value.GenreRoomID + "," + value.StatusRoom + "," + value.NumRow + "," + value.NumCol + ")";
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException)
            {
                return 0;
            }
            string query1 = "SELECT IDENT_CURRENT('dbo.Room') AS 'top'";
            DataTable table = DataProvider.Instace.ExecuteQuery(query1);
            return int.Parse(table.Rows[0][0].ToString());
        }
        //
        // PUT: api/Rooms/5
        public int Put(int id, [FromBody]Room value)
        {
            string query = "UPDATE dbo.Room SET RoomName = N'"+value.RoomName+"', GenreRoomID = "+value.GenreRoomID+",StatusRoom="+value.StatusRoom+",NumRow="+value.NumRow+",NumCol="+value.NumCol+" WHERE RoomID =" + id;
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

        // DELETE: api/Rooms/5
        public int Delete(int id)
        {
            string query = "DELETE  dbo.Room WHERE RoomID = " + id;
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