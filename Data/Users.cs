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
    
    public partial class Users
    {
        public Users()
        {
            this.Messages = new HashSet<Messages>();
            this.Sessions = new HashSet<Sessions>();
        }
    
        public int Id { get; set; }
        public string Nickname { get; set; }
    
        public virtual ICollection<Messages> Messages { get; set; }
        public virtual ICollection<Sessions> Sessions { get; set; }
    }
}