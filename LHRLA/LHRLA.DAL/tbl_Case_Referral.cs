//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LHRLA.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Case_Referral
    {
        public int ID { get; set; }
        public Nullable<int> Case_ID { get; set; }
        public Nullable<int> Agency_ID { get; set; }
        public string Agency_Role_Description { get; set; }
    
        public virtual tbl_Case tbl_Case { get; set; }
    }
}
