namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Film_GenreFilm
    {
        public int ID { get; set; }

        public int FilmID { get; set; }

        public int GenreFilmID { get; set; }

        public virtual Film Film { get; set; }

        public virtual Genre_film Genre_film { get; set; }
    }
}
