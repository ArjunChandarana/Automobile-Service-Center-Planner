//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ACS.DAL.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class SelectedService
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public int ServiceId { get; set; }
    
        public virtual ServiceBooking ServiceBooking { get; set; }
        public virtual Service Service { get; set; }
    }
}
