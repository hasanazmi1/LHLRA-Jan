using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace LHRLA.Core.ViewModel
{
    public class MenuVM
    {
        public int? UserId { get; set; }
        public int? SectionID { get; set; }
        public string Section { get; set; }
        public int? SectionSequence { get; set; }
        public string Page { get; set; }
        public int? PageID { get; set; }
        public string URL { get; set; }
        public int? PageSequence { get; set; }
    }
}
