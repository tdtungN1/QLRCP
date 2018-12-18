namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Film()
        {
            Film_GenreFilm = new HashSet<Film_GenreFilm>();
            ShowTimes = new HashSet<ShowTime>();
        }

        public int FilmID { get; set; }

        [Required]
        [StringLength(255)]
        public string FilmName { get; set; }

        [StringLength(255)]
        public string Author { get; set; }

        [StringLength(255)]
        public string Producer { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(50)]
        public string Nation { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public double? Rated { get; set; }

        [StringLength(200)]
        public string Actor { get; set; }

        public byte? Status { get; set; }

        [Column(TypeName = "text")]
        public string Images { get; set; }

        [Column(TypeName = "text")]
        public string Trailer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Film_GenreFilm> Film_GenreFilm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
