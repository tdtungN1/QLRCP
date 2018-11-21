using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebAPI.Models
{
    public class DataProvider
    {
        private static DataProvider _instace;
        public static DataProvider Instace
        {
            get
            {
                if (_instace == null)
                    _instace = new DataProvider();
                return _instace;
            }
            private set
            {
                _instace = value;
            }
        }
        private DataProvider() { }
        private void getPramaeter(SqlCommand cmd, string query, List<string> pramaeter = null)
        {
            if (pramaeter != null)
            {
                string[] listprameter = query.Split(' ');
                int i = 0;
                foreach (string item in listprameter)
                {
                    if (item.Contains("@"))
                    {
                        cmd.Parameters.AddWithValue(item, pramaeter[i]);
                        i++;
                    }
                }
            }
        }

        string connectring = WebConfigurationManager.ConnectionStrings["QLRCP"].ConnectionString;

        public DataTable ExecuteQuery(string query, List<string> pramaeter = null)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(connectring);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            getPramaeter(cmd, query, pramaeter);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(data);

            connection.Close();
            return data;
        }

        public int ExecuteNonQuery(string query, List<string> pramaeter = null)
        {
            int data = 0;
            SqlConnection connection = new SqlConnection(connectring);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);

            getPramaeter(cmd, query, pramaeter);

            data = cmd.ExecuteNonQuery();

            connection.Close();
            return data;
        }

    }
}