using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class TagsSetupDataAccess
    {
        #region Insert
        public bool AddTagsSetup(tbl_Tags_Setup row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Tags_Setup.Add(row);
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

        public bool UpdateTagsSetup(tbl_Tags_Setup row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Tags_Setup val = new tbl_Tags_Setup();
                    val = db.tbl_Tags_Setup.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Tag_Value = row.Tag_Value;
                    val.Tag_Description = row.Tag_Description;
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
        public List<tbl_Tags_Setup> GetAllTagsSetup()
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Tags_Setup> GetAllActiveTagsSetup()
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.ToList().Where(a => a.Is_Active == true).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Tags_Setup> CheckDuplicateData(string TagValue)
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.ToList().Where(a => a.Tag_Value == TagValue).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        public List<tbl_Tags_Setup> GetTagsSetupbyID(int ID)
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Tags_Setup> GetTagsSetupbyIDOnUpdate(int ID,string value )
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.Where(e => e.ID != ID && e.Tag_Value == value).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Tags_Setup> GetTagsSetupbyIDValue(int ID, string value)
        {
            try
            {
                List<tbl_Tags_Setup> lst = new List<tbl_Tags_Setup>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Tags_Setup.Where(e => e.ID == ID && e.Tag_Value == value).ToList();
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