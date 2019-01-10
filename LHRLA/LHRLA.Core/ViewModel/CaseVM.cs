using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHRLA.DAL;
 
namespace LHRLA.Core.ViewModel
{
    public class CaseVM : tbl_Case
    {
        public string SubType { get; set; }
        public int SubTypeId { get; set; }
        public string Type { get; set; }
        public string RegisterationType { get; set; }
        public string Status { get; set; }
        public string Referral { get; set; }
        public string Tag { get; set; }
       

    }
}
