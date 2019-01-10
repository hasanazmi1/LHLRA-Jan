using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class SectionDataAccess
    {
        #region Insert
        public bool AddSection(tbl_Section row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Section.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region Update

        public bool UpdateSection(tbl_Section row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Section val = new tbl_Section();
                    val = db.tbl_Section.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Title = row.Title;
                    val.Is_Active = row.Is_Active;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Delete

        #endregion

        #region Select
        public List<tbl_Section> GetAllSections()
        {
            try
            {
                List<tbl_Section> lst = new List<tbl_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Section.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Section> GetAllActiveSections()
        {
            try
            {
                List<tbl_Section> lst = new List<tbl_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Section.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Section> GetSectionbyID(int ID)
        {
            try
            {
                List<tbl_Section> lst = new List<tbl_Section>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Section.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetSectionName(int SectionID)
        {
            try
            {
                string SectionName="";
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Section sec = new tbl_Section();
                    sec = db.tbl_Section.Where(e => e.ID == SectionID).FirstOrDefault();
                    if (sec != null)
                    {
                        SectionName = sec.Title;
                    }
                }
                return SectionName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion
    }
}