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
            ShowTimes = new HashSet<ShowTime>();
        }

        public int RoomID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoomName { get; set; }

        public int GenreRoomID { get; set; }

        public byte StatusRoom { get; set; }

        public int? NumRow { get; set; }

        public int? NumCol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chair> Chairs { get; set; }

        public virtual Genre_room Genre_room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
