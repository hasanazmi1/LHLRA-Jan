using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHRLA.DAL;
namespace LHRLA.Core.ViewModel
{ 
    public class RolePageVM : tbl_Role_Pages
    {
        public string PageTitle { get; set; }
        public int? SectionID { get; set; }
        public string SectionName { get; set; }
    }
}
