namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int TicketID { get; set; }

        public int? ChairID { get; set; }

        public int? FilmID { get; set; }

        public DateTime? StartTime { get; set; }

        public long Price { get; set; }

        public int? UserID { get; set; }

        public virtual Chair Chair { get; set; }

        public virtual Film Film { get; set; }

        public virtual User User { get; set; }
    }
}
