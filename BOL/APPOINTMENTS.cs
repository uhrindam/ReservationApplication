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
    
    public partial class APPOINTMENTS
    {
        public string ID { get; set; }
        public string NickName { get; set; }
        public string CategoryName { get; set; }
        public Nullable<System.DateTime> ReservationDate { get; set; }
        public Nullable<int> CurrentPrice { get; set; }
        public Nullable<System.DateTime> StartingPont { get; set; }
        public Nullable<System.DateTime> EndingPoint { get; set; }
        public Nullable<bool> IsNotDeleted { get; set; }
    
        public virtual CATEGORIES CATEGORIES { get; set; }
        public virtual USERS USERS { get; set; }
    }
}