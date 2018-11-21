namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthday { get; set; }

        public int? UserID { get; set; }

        public virtual User User { get; set; }
    }
}
