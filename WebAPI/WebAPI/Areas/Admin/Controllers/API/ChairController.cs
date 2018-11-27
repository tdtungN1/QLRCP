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
    public class ChairController : ApiController
    {
        // GET: api/Chair
        public IEnumerable<Chair> Get()
        {
            List<Chair> chairs = new List<Chair>();
            string query = "SELECT * FROM dbo.Chair";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Chair item = new Chair();
                item.ChairID = int.Parse(row["ChairID"].ToString());
                item.ChairName = row["ChairName"].ToString();
                item.GenreChairID = int.Parse(row["GenreChairID"].ToString());
                item.RoomID = int.Parse(row["RoomID"].ToString());
                chairs.Add(item);
            }
            return chairs;
        }

        // GET: api/Chair/5
        public Chair Get(int id)
        {
            string query = "SELECT * from dbo.Chair WHERE ChairID = "+ id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Chair chair = new Chair();
            chair.ChairID = int.Parse(table.Rows[0]["ChairID"].ToString());
            chair.ChairName = table.Rows[0]["ChairName"].ToString();
            chair.GenreChairID = int.Parse(table.Rows[0]["GenreChairID"].ToString());
            chair.RoomID = int.Parse(table.Rows[0]["RoomID"].ToString());
            return chair;
        }

        // POST: api/Chair
        public int Post(List<Chair> value)
        {
            foreach (var item in value)
            {
                string query = "INSERT dbo.Chair(ChairName,RoomID,GenreChairID)VALUES (N'"+item.ChairName+"',"+item.RoomID+","+item.GenreChairID+")";
                int table = DataProvider.Instace.ExecuteNonQuery(query);
            }
            return 1;
        }

        // PUT: api/Chair/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Chair/5
        public int Delete(int id)
        {
            string query = "DELETE  dbo.Chair WHERE RoomID = " + id;
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
