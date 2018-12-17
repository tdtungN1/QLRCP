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
    public class FilmController : ApiController
    {
        // GET: api/Film/?status=1
        [HttpGet]
        public IEnumerable<Film> GetFilmCurrent(byte status)
        {
            List<Film> films = new List<Film>();
            string query = "SELECT * FROM dbo.Film WHERE Status = " + status;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Film item = new Film();
                item.FilmID = int.Parse(row["FilmID"].ToString());
                item.FilmName = row["FilmName"].ToString();
                item.Author = row["Author"].ToString();
                item.Producer = row["Producer"].ToString();
                item.ReleaseDate = DateTime.Parse(row["ReleaseDate"].ToString());
                item.Nation = row["Nation"].ToString();
                item.Description = row["Description"].ToString();
                item.Rated = float.Parse(row["Rated"].ToString());
                item.Actor = row["Actor"].ToString();
                item.Status = byte.Parse(row["Status"].ToString());
                films.Add(item);
            }
            return films;
        }

        // GET: api/Film
        [HttpGet]
        public IEnumerable<Film> GetAllFilm()
        {
            List<Film> films = new List<Film>();
            string query = "SELECT * FROM dbo.Film ORDER BY Status";
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Film item = new Film();
                item.FilmID = int.Parse(row["FilmID"].ToString());
                item.FilmName = row["FilmName"].ToString();
                item.Author = row["Author"].ToString();
                item.Producer = row["Producer"].ToString();
                item.ReleaseDate = DateTime.Parse(row["ReleaseDate"].ToString());
                item.Nation = row["Nation"].ToString();
                item.Description = row["Description"].ToString();
                item.Rated = float.Parse(row["Rated"].ToString());
                item.Actor = row["Actor"].ToString();
                item.Status = byte.Parse(row["Status"].ToString());
                films.Add(item);
            }
            return films;
        }

        // GET: api/Film/5
        public Film Get(int id)
        {
            string query = "SELECT * FROM dbo.Film WHERE FilmID = " + id;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            Film film = new Film();
            film.FilmID = int.Parse(table.Rows[0]["FilmID"].ToString());
            film.FilmName = table.Rows[0]["FilmName"].ToString();
            film.Author = table.Rows[0]["Author"].ToString();
            film.Producer = table.Rows[0]["Producer"].ToString();
            film.ReleaseDate = DateTime.Parse(table.Rows[0]["ReleaseDate"].ToString());
            film.Nation = table.Rows[0]["Nation"].ToString();
            film.Description = table.Rows[0]["Description"].ToString();
            film.Rated = float.Parse(table.Rows[0]["Rated"].ToString());
            film.Actor = table.Rows[0]["Actor"].ToString();
            film.Status = byte.Parse(table.Rows[0]["Status"].ToString());

            string query1 = "SELECT fg.*,g.GenreFilmName FROM dbo.Film_GenreFilm fg JOIN dbo.Genre_film g ON g.GenreFilmID = fg.GenreFilmID WHERE FilmID =" + id;
            DataTable table1 = DataProvider.Instace.ExecuteQuery(query1);
            List<Film_GenreFilm> film_GenreFilms = new List<Film_GenreFilm>();
            foreach (DataRow row in table1.Rows)
            {
                Film_GenreFilm item = new Film_GenreFilm();
                item.FilmID = int.Parse(row["FilmID"].ToString());
                item.GenreFilmID = int.Parse(row["GenreFilmID"].ToString());
                item.ID = int.Parse(row["ID"].ToString());
                Genre_film genre_Film = new Genre_film();
                genre_Film.GenreFilmID = int.Parse(row["GenreFilmID"].ToString());
                genre_Film.GenreFilmName = row["GenreFilmName"].ToString();
                item.Genre_film = genre_Film;
                film_GenreFilms.Add(item);
            }
            film.Film_GenreFilm = film_GenreFilms;
            return film;
        }

        // POST: api/Film
        public int Post([FromBody]Film value)
        {
            string query = "INSERT dbo.Film(FilmName,Author,Producer,ReleaseDate,Nation,Description,Rated,Actor,Status)VALUES(N'" + value.FilmName + "',N'" + value.Author + "',N'" + value.Producer + "','" + value.ReleaseDate + "',N'" + value.Nation + "','" + value.Description + "'," + value.Rated + ",N'" + value.Actor + "'," + value.Status + ")";
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException ex)
            {
                return 0;
            }
            string query1 = "SELECT IDENT_CURRENT('dbo.Film') AS 'top'";
            DataTable table = DataProvider.Instace.ExecuteQuery(query1);
            return int.Parse(table.Rows[0][0].ToString());
        }

        // PUT: api/Film/5
        public int Put(int id, [FromBody]Film value)
        {
            string query = "UPDATE dbo.Film SET FilmName = N'" + value.FilmName + "', Author = N'" + value.Author + "', Producer=N'" + value.Nation + "',ReleaseDate='" + value.ReleaseDate + "',Description=" + value.Description + ",Rated="+value.Rated+ ",Actor=N'"+value.Actor+ "',Status="+value.Status+" WHERE FilmID =" + id;
            try
            {
                int res = DataProvider.Instace.ExecuteNonQuery(query);
            }
            catch (SqlException ex)
            {
                return 0;
            }
            return 1;
        }

        // DELETE: api/Film/5
        public int Delete(int id)
        {
            string query = "DELETE  dbo.Film WHERE FilmID = " + id;
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
