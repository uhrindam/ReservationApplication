//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            this.APPOINTMENTS = new HashSet<APPOINTMENTS>();
        }
    
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        //SHA-1 encryption
        public string Passwd { get; set; }
        public Nullable<System.DateTime> RegistrationDate { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENTS> APPOINTMENTS { get; set; }
    }
}
