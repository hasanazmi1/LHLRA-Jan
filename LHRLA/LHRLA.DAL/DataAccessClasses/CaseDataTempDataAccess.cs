using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseDataTempDataAccess
    {

        #region Insert
        public bool AddCaseDataTemp(tbl_Case_Data_temp row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Data_temp.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddAllCaseTempData(List<tbl_Case_Data_temp> rows)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Data_temp.AddRange(rows);
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

        public bool UpdateCaseDataTemp(tbl_Case_Data_temp row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Data_temp val = new tbl_Case_Data_temp();
                    val = db.tbl_Case_Data_temp.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.CaseHistoryLogID = row.CaseHistoryLogID;
                    val.Case_Field_ID = row.Case_Field_ID;
                    val.Case_ID = row.Case_ID;
                    val.Field_Value = row.Field_Value;
                    val.Description = row.Description;

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
        public List<tbl_Case_Data_temp> GetAllCaseDataTemp()
        {
            try
            {
                List<tbl_Case_Data_temp> lst = new List<tbl_Case_Data_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data_temp.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Branch> GetAllActiveBranches()
        //{
        //    try
        //    {
        //        List<tbl_Branch> lst = new List<tbl_Branch>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Branch.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;l
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Case_Data_temp> GetCaseDataTempbyID(int ID)
        {
            try
            {
                List<tbl_Case_Data_temp> lst = new List<tbl_Case_Data_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data_temp.Where(e => e.Case_Field_ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Data_temp> GetCaseDataTempbyCase(int CaseId,int LogId)
        {
            try
            {
                List<tbl_Case_Data_temp> lst = new List<tbl_Case_Data_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data_temp.Where(e => e.Case_ID == CaseId && e.CaseHistoryLogID==LogId).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case_Data_temp> GetCaseDataTempbyLogId(int LogId)
        {
            try
            {
                List<tbl_Case_Data_temp> lst = new List<tbl_Case_Data_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Data_temp.Where(e => e.CaseHistoryLogID == LogId).ToList();
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