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
    
    public partial class tbl_Case_Fields_Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Case_Fields_Section()
        {
            this.tbl_Case_Fields = new HashSet<tbl_Case_Fields>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<int> Sequence_No { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Case_Fields> tbl_Case_Fields { get; set; }
    }
}
