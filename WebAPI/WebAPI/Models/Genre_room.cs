namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Genre_room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genre_room()
        {
            Rooms = new HashSet<Room>();
        }

        public Genre_room(int genreRoomID, string genreRoomName)
        {
            GenreRoomID = genreRoomID;
            GenreRoomName = genreRoomName;
        }

        [Key]
        public int GenreRoomID { get; set; }

        [Required]
        [StringLength(30)]
        public string GenreRoomName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
