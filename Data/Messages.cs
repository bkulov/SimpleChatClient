//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int Id { get; set; }
        public int Id_Sender { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public string MessageText { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
