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
    
    public partial class tbl_Case_Tags
    {
        public int ID { get; set; }
        public int Case_ID { get; set; }
        public int Tag_ID { get; set; }
    
        public virtual tbl_Case tbl_Case { get; set; }
        public virtual tbl_Tags_Setup tbl_Tags_Setup { get; set; }
    }
}