namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPOINTMENTS
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NickName { get; set; }

        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }

        public DateTime? ReservationDate { get; set; }

        public int? CurrentPrice { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual CATEGORIES CATEGORIES { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
