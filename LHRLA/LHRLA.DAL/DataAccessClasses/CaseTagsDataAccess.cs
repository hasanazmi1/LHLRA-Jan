using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseTagsDataAccess
    {
        #region Insert
        public bool AddCaseTags(tbl_Case_Tags row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Tags.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddAllCaseTags(List<tbl_Case_Tags> rows)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Tags.AddRange(rows);
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

        //#region Update

        //public bool UpdateCaseSubTypes(tbl_Case_Sub_Types row)
        //{

        //    try
        //    {
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            tbl_Case_Sub_Types val = new tbl_Case_Sub_Types();
        //            val = db.tbl_Case_Sub_Types.Where(a => a.ID == row.ID).FirstOrDefault();
        //            val.Type = row.Type;
        //            val.Description = row.Description;
        //            val.Is_Active = row.Is_Active;
        //            db.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //#endregion

        #region Delete
        public bool DeleteCaseTags(int CaseId)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_Case_Tags> rows = new List<tbl_Case_Tags>();
                    rows = db.tbl_Case_Tags.Where(a => a.Case_ID == CaseId).ToList();
                    db.tbl_Case_Tags.RemoveRange(rows);
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

        #region Select
        public List<tbl_Case_Tags> GetAllCaseTags()
        {
            try
            {
                List<tbl_Case_Tags> lst = new List<tbl_Case_Tags>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Tags.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Case_Tags> GetAllActiveCaseSubTypes()
        //{
        //    try
        //    {
        //        List<tbl_Case_Tags> lst = new List<tbl_Case_Tags>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Case_Tags.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Case_Tags> GetCaseTagsbyID(int ID)
        {
            try
            {
                List<tbl_Case_Tags> lst = new List<tbl_Case_Tags>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Tags.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Tags> GetCaseTagsbyCaseID(int CaseId)
        {
            try
            {
                List<tbl_Case_Tags> lst = new List<tbl_Case_Tags>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Tags.Where(e => e.Case_ID==CaseId).ToList();
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