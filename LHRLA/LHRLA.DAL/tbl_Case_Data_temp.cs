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
    
    public partial class tbl_Case_Data_temp
    {
        public int ID { get; set; }
        public Nullable<int> CaseHistoryLogID { get; set; }
        public Nullable<int> Case_Field_ID { get; set; }
        public Nullable<int> Case_ID { get; set; }
        public string Field_Value { get; set; }
        public string Description { get; set; }
    
        public virtual tbl_Case tbl_Case { get; set; }
        public virtual tbl_Case_Fields tbl_Case_Fields { get; set; }
        public virtual tbl_Case_History_Log tbl_Case_History_Log { get; set; }
    }
}
