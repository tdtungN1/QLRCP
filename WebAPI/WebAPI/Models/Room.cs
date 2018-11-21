namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            Chairs = new HashSet<Chair>();
        }

        public Room(int roomID, string roomName, int genreRoomID, byte statusRoom, ICollection<Chair> chairs, Genre_room genre_room)
        {
            RoomID = roomID;
            RoomName = roomName;
            GenreRoomID = genreRoomID;
            StatusRoom = statusRoom;
            Chairs = chairs;
            Genre_room = genre_room;
        }

        public int RoomID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomName { get; set; }

        public int GenreRoomID { get; set; }

        public byte StatusRoom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chair> Chairs { get; set; }

        public virtual Genre_room Genre_room { get; set; }
    }
}
