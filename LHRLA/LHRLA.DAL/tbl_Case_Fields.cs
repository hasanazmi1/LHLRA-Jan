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
    
    public partial class tbl_Case_Fields
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Case_Fields()
        {
            this.tbl_Case_Data = new HashSet<tbl_Case_Data>();
            this.tbl_Case_Data_temp = new HashSet<tbl_Case_Data_temp>();
            this.tbl_Case_Fields_Options = new HashSet<tbl_Case_Fields_Options>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Field_Type { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<int> Sequence_No { get; set; }
        public Nullable<bool> Is_Mandatory { get; set; }
        public Nullable<bool> Is_Visible_On_App { get; set; }
        public Nullable<int> Case_Field_Section_ID { get; set; }
        public Nullable<bool> Is_Encrypted { get; set; }
        public Nullable<bool> Is_Hidden { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Case_Data> tbl_Case_Data { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Case_Data_temp> tbl_Case_Data_temp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Case_Fields_Options> tbl_Case_Fields_Options { get; set; }
        public virtual tbl_Case_Fields_Section tbl_Case_Fields_Section { get; set; }
    }
}