using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL
{
    public class CaseHistoryLogDataAccess
    {
        #region Insert
        public int AddCaseHistoryLog(tbl_Case_History_Log row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_History_Log.Add(row);
                    db.SaveChanges();

                }
                return row.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int CreateCaseHistoryLog(tbl_Case_History_Log row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case_History_Log.Add(row);
                    db.SaveChanges();

                }
                return row.ID;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Update

        public bool UpdateCaseHistoryLog(tbl_Case_History_Log row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_History_Log val = new tbl_Case_History_Log();
                    val = db.tbl_Case_History_Log.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_ID = row.Case_ID;
                    val.Old_Data = row.Old_Data;
                    val.New_Data = row.New_Data;
                    val.Approval1_User = row.Approval1_User;
                    val.Approval1_Datetime = row.Approval1_Datetime;
                    val.Approval1_Comments = row.Approval1_Comments;
                    val.Approval2_User = row.Approval2_User;
                    val.Approval2_Datetime = row.Approval2_Datetime;
                    val.Approval2_Comments = row.Approval2_Comments;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCaseHistoryApproval(int LogId,int UserId,string Comments)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case_History_Log val = new tbl_Case_History_Log();
                    val = db.tbl_Case_History_Log.Where(a => a.ID == LogId).FirstOrDefault();
                    if (val.Approval1_Datetime != null)
                    {
                        val.Approval1_User = UserId;
                        val.Approval1_Datetime = DateTime.Now;
                        val.Approval1_Comments = Comments;
                    }
                    else
                    {
                        val.Approval2_User = UserId;
                        val.Approval2_Datetime = DateTime.Now;
                        val.Approval2_Comments = Comments;
                    }
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
        public List<tbl_Case_History_Log> GetAllCaseHistoryLogs()
        {
            try
            {
                List<tbl_Case_History_Log> lst = new List<tbl_Case_History_Log>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_History_Log.ToList();
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



        public tbl_Case_History_Log GetCaseHistoryLogsbyID(int ID)
        {
            try
            {
                tbl_Case_History_Log lst = new tbl_Case_History_Log();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_History_Log.Where(e => e.ID == ID).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbl_Case_History_Log GetCaseHistoryLogsbyCaseID(int CaseID)
        {
            try
            {
                tbl_Case_History_Log lst = new tbl_Case_History_Log();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case_History_Log.Where(e => e.Case_ID==CaseID).OrderByDescending(a=>a.ID).FirstOrDefault();
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