namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int TicketID { get; set; }

        public virtual Order Order { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
