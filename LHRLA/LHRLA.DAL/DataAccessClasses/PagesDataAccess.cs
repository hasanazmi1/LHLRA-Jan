using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class PagesDataAccess
    {
        #region Insert
        public bool AddPages(tbl_Pages row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Pages.Add(row);
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

        public bool UpdatePages(tbl_Pages row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Pages val = new tbl_Pages();
                    val = db.tbl_Pages.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Title = row.Title;
                    val.URL = row.URL;
                    val.Description = row.Description;
                    val.Is_Active = row.Is_Active;
                    val.Section_ID = row.Section_ID;
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
        public List<tbl_Pages> GetAllPages()
        {
            try
            {
                List<tbl_Pages> lst = new List<tbl_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Pages.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Pages> GetAllActivePages()
        {
            try
            {
                List<tbl_Pages> lst = new List<tbl_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Pages.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<tbl_Pages> GetPagesbyID(int ID)
        {
            try
            {
                List<tbl_Pages> lst = new List<tbl_Pages>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Pages.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        #endregion
    }
}