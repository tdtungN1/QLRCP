namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Genre_film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genre_film()
        {
            Film_GenreFilm = new HashSet<Film_GenreFilm>();
        }

        [Key]
        public int GenreFilmID { get; set; }

        [Required]
        [StringLength(30)]
        public string GenreFilmName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Film_GenreFilm> Film_GenreFilm { get; set; }
    }
}
