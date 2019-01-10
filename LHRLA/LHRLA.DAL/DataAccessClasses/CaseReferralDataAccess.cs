using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL
{
    public class CaseReferralDataAccess
    {
        #region Insert
        public bool AddCaseReferral(tbl_Case_Referral row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Referral.Add(row);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddAllCaseReferral(List<tbl_Case_Referral> rows)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_Referral.AddRange(rows);
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

        public bool UpdateCaseReferral(tbl_Case_Referral row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_Referral val = new tbl_Case_Referral();
                    val = db.tbl_Case_Referral.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_ID = row.Case_ID;
                    val.Case_ID = row.Case_ID;
                    val.Agency_ID = row.Agency_ID;
                    val.Agency_Role_Description = row.Agency_Role_Description;
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
        public bool DeleteCaseReferral(int CaseId)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    List<tbl_Case_Referral> rows = new List<tbl_Case_Referral>();
                    rows = db.tbl_Case_Referral.Where(a => a.Case_ID == CaseId).ToList();
                    db.tbl_Case_Referral.RemoveRange(rows);
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
        public List<tbl_Case_Referral> GetAllCaseReferral()
        {
            try
            {
                List<tbl_Case_Referral> lst = new List<tbl_Case_Referral>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Referral.ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<tbl_Case_History_Log> GetAllActiveCaseFiledsSections()
        //{
        //    try
        //    {
        //        List<tbl_Case_History_Log> lst = new List<tbl_Case_History_Log>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Case_History_Log.ToList().Where(a => a.Is_Active == true).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public List<tbl_Case_Referral> GetCaseReferralbyID(int ID)
        {
            try
            {
                List<tbl_Case_Referral> lst = new List<tbl_Case_Referral>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Referral.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case_Referral> GetCaseReferralbyCaseId(int CaseId)
        {
            try
            {
                List<tbl_Case_Referral> lst = new List<tbl_Case_Referral>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_Referral.Where(e => e.Case_ID==CaseId).ToList();
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