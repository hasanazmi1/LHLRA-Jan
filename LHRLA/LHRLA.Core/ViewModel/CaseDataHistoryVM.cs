using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHRLA.DAL;

namespace LHRLA.Core.ViewModel 
{
    public class CaseDataHistoryVM
    {
        
        public DateTime ?Case_DateTime { get; set; }
        public string Case_Type { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        
        public string Branch { get; set; }
        public string Counselor { get; set; }
        public DateTime ?Followup_Date { get; set; }
        public string Case_Status { get; set; }


        public DateTime ?New_Case_DateTime { get; set; }
        public string New_Case_Type { get; set; }
        public string New_Summary { get; set; }
        public string New_Description { get; set; }
        
        public string New_Branch { get; set; }
        public string New_Counselor { get; set; }
        public DateTime ?New_Followup_Date { get; set; }
        public string New_Case_Status { get; set; }

    }
}
