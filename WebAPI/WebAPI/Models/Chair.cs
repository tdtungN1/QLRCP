namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chair")]
    public partial class Chair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chair()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ChairID { get; set; }

        [Required]
        [StringLength(10)]
        public string ChairName { get; set; }

        public int RoomID { get; set; }

        public int GenreChairID { get; set; }

        public virtual Genre_chair Genre_chair { get; set; }

        public virtual Room Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
