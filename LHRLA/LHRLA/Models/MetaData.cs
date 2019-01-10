using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LHRLA.Models
{
    

    public class tbl_Case_TypesMetaData
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Required")]
        public string Type { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Is_Active { get; set; }
    }
}