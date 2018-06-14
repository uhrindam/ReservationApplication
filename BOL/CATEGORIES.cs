namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CATEGORIES
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIES()
        {
            APPOINTMENTS = new HashSet<APPOINTMENTS>();
        }

        [Key]
        [StringLength(255)]
        public string CategoryName { get; set; }

        public int? Price { get; set; }

        public int? ProcessLengthInMunites { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENTS> APPOINTMENTS { get; set; }
    }
}
