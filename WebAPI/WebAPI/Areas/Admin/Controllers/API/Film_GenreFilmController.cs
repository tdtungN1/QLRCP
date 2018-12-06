﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Areas.Admin.Controllers.API
{
    public class Film_GenreFilmController : ApiController
    {
        // GET: api/Film_GenreFilm/?FilmID=
        public Film_GenreFilm Get(int FilmID, int GenreFilmID)
        {
            Film_GenreFilm film_GenreFilms = new Film_GenreFilm();
            string query = "SELECT * FROM dbo.Film_GenreFilm WHERE FilmID = " + FilmID + " AND GenreFilmID = " + GenreFilmID;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);

            Film_GenreFilm item = new Film_GenreFilm();
            item.GenreFilmID = int.Parse(table.Rows[0]["GenreFilmID"].ToString());
            item.FilmID = int.Parse(table.Rows[0]["FilmID"].ToString());


            return film_GenreFilms;
        }

        // GET: api/Film_GenreFilm/?FilmID=5
        public IEnumerable<Film_GenreFilm> GetByFilm(int FilmID)
        {
            List<Film_GenreFilm> film_GenreFilms = new List<Film_GenreFilm>();
            string query = "SELECT * FROM dbo.Film_GenreFilm WHERE FilmID = " + FilmID;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Film_GenreFilm item = new Film_GenreFilm();
                item.GenreFilmID = int.Parse(row["GenreFilmID"].ToString());
                item.FilmID = int.Parse(row["FilmID"].ToString());
                film_GenreFilms.Add(item);
            }
            return film_GenreFilms;
        }


        public IEnumerable<Film_GenreFilm> GetByGenreFilm(int GenreFilmID)
        {
            List<Film_GenreFilm> film_GenreFilms = new List<Film_GenreFilm>();
            string query = "SELECT * FROM dbo.Film_GenreFilm WHERE GenreFilmID = " + GenreFilmID;
            DataTable table = DataProvider.Instace.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                Film_GenreFilm item = new Film_GenreFilm();
                item.GenreFilmID = int.Parse(row["GenreFilmID"].ToString());
                item.FilmID = int.Parse(row["FilmID"].ToString());
                film_GenreFilms.Add(item);
            }
            return film_GenreFilms;
        }
        // POST: api/Film_GenreFilm
        public int Post([FromBody]List<Film_GenreFilm> value)
        {
            foreach (var item in value)
            {
                string query = "INSERT dbo.Film_GenreFilm(FilmID,GenreFilmID)VALUES (" + item.FilmID + "," + item.GenreFilmID + ")";
                int table = DataProvider.Instace.ExecuteNonQuery(query);
            }
            return 1;
        }

        // PUT: api/Film_GenreFilm/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Film_GenreFilm/5
        public void Delete(int id)
        {
        }
    }
}
