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
    
    public partial class tbl_User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_User()
        {
            this.tbl_Email_Users = new HashSet<tbl_Email_Users>();
            this.tbl_User_Branch = new HashSet<tbl_User_Branch>();
        }
    
        public long ID { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Nullable<int> Role_ID { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Nullable<int> City_ID { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<int> Supervisor_ID { get; set; }
    
        public virtual tbl_City tbl_City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Email_Users> tbl_Email_Users { get; set; }
        public virtual tbl_Role tbl_Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_User_Branch> tbl_User_Branch { get; set; }
    }
}
