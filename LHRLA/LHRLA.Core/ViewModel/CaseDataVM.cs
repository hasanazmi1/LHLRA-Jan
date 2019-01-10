using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHRLA.DAL;
 
namespace LHRLA.Core.ViewModel
{
    public class CaseDataVM : tbl_Case_Data
    {
        public string SectionTitle { get; set; }
        public string FieldTitle { get; set; }
        public int Section_ID { get; set; }
        public string Field_Type{ get; set; }
    }
}
