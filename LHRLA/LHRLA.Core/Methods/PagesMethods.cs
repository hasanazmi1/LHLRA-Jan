using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LHRLA.DAL; 
using LHRLA.Core.ViewModel;


namespace LHRLA.Core.Methods
{
   public class PagesMethods
    {
        public static List<PageSectionVM> GetAllSectionPages()
        {
            try
            { 
                var data = new LHRLA.DAL.DataAccessClasses.PagesDataAccess().GetAllActivePages();
                if (data != null)
                {
                    return data.Select(e => new PageSectionVM
                    {
                        ID = e.ID,
                        Title = e.Title,
                        Is_Active = e.Is_Active,
                        URL = e.URL,
                        Section_ID = e.Section_ID,
                        SectionTitle = new LHRLA.DAL.DataAccessClasses.SectionDataAccess().GetSectionName(int.Parse(e.Section_ID.ToString())),
                    }).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
