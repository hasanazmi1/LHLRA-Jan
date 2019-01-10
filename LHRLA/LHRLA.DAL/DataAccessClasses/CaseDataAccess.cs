using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseDataAccess
    {
        #region Insert
        public int AddCase(tbl_Case row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_Case.Add(row);
                    db.SaveChanges();
                    return row.ID;//this ID will be used to add the dynamic case fields data

                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        #endregion

        #region Update

        #region approval level
        public bool MarkRejection(int CaseID)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == CaseID).FirstOrDefault();
                    val.Approval_Level = 0;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateApproval(int CaseID)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == CaseID).FirstOrDefault();
                    if (val.Approval_Level == 0)
                    {
                        val.Approval_Level = 1;
                    }
                    else if (val.Approval_Level == 1)
                    {
                        val.Approval_Level = 2;
                    }
                    else if (val.Approval_Level == 2)
                    {
                        val.Approval_Level = 0;
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

        #region transfer
        public bool UpdateCaseCounseller(int CaseID,int NewUserID)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == CaseID).FirstOrDefault();
                    val.CounselorId = NewUserID;
                    val.Approval_Level = 0;
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

        #region followup
        public bool UpdateCaseFollowup(int CaseID, DateTime FollowupDate)
        {
            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == CaseID).FirstOrDefault();
                    val.Followup_Date = FollowupDate;
                    val.Approval_Level = 0;
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

        #region status
        public bool UpdateCaseStatus(int CaseID, int NewStatusID)
        {
            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == CaseID).FirstOrDefault();
                    val.Current_Status_ID = NewStatusID;
                    val.Approval_Level = 0;
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


        public bool UpdateCase(tbl_Case row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_Code = row.Case_Code;
                    val.Case_DateTime = row.Case_DateTime;
                    val.Case_Type_Id = row.Case_Type_Id;
                    val.Summary = row.Summary;
                    val.Description = row.Description;
                    val.Case_Registeration_Type_Id = row.Case_Registeration_Type_Id;
                    val.Attachment_Count = row.Attachment_Count;
                    val.Is_Submitted = row.Is_Submitted;
                    val.Current_Status_ID = row.Current_Status_ID;
                    val.Call_ID = row.Call_ID;
                    val.Linked_Case_ID = row.Linked_Case_ID;
                    val.Case_Reference_Person = row.Case_Reference_Person;
                    val.Approval_Level = row.Approval_Level;
                    val.Client_Name = row.Client_Name;
                    val.Client_Contact = row.Client_Contact;
                    val.Client_CNIC = row.Client_CNIC;
                    val.Followup_Date = row.Followup_Date;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Update Case on Approval
        public bool UpdateCaseDetailsOnApproval(tbl_case_temp row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_Case val = new tbl_Case();
                    val = db.tbl_Case.Where(a => a.ID == row.Case_ID).FirstOrDefault();
                    val.Case_DateTime = row.Case_DateTime;
                    val.Case_Type_Id = row.Case_Type_Id;
                    val.Summary = row.Summary;
                    val.Description = row.Description;
                    val.Branch_ID = row.Branch_ID;
                    val.Approval_Level = 0;
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

        #endregion

        #region Delete

        #endregion

        #region Select
        public List<tbl_Case> GetAllCases()
        {
            try
            {
                List<tbl_Case> lst = new List<tbl_Case>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case.ToList();
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
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        public tbl_Case GetCasebyID(int ID)
        {
            try
            {
                tbl_Case lst = new tbl_Case();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case.Where(a=>a.ID==ID).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_Case> GetCasebyUserID(int UserID)
        {
            try
            {
                List<tbl_Case> lst = new List<tbl_Case>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case.Where(e => e.UserID==UserID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<tbl_Case> GetCasebyBranch(int ID)
        {
            try
            {
                List<tbl_Case> lst = new List<tbl_Case>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_Case.Where(e => e.ID == ID).ToList();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetCaseSupervisor(int CaseId,int? ApprovalLevel)
        {
            try
            {
                int SupervisorId = 0;
                int CounselorId = 0;
                using (var db = new vt_LHRLAEntities())
                {
                    CounselorId = int.Parse(db.tbl_Case.Where(e => e.ID==CaseId).FirstOrDefault().CounselorId.ToString());
                    SupervisorId= int.Parse(db.tbl_User.Where(a => a.ID == CounselorId).FirstOrDefault().Supervisor_ID.ToString());
                    if (ApprovalLevel == 2)
                    {
                        SupervisorId = int.Parse(db.tbl_User.Where(a => a.ID == SupervisorId).FirstOrDefault().Supervisor_ID.ToString());
                    }
                }
                return SupervisorId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //public List<tbl_Case> GetCasebyID(int ID)
        //{
        //    try
        //    {
        //        List<tbl_Case> lst = new List<tbl_Case>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Case.Where(e => e.ID == ID).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public List<tbl_Case> GetCasebyID(int ID)
        //{
        //    try
        //    {
        //        List<tbl_Case> lst = new List<tbl_Case>();
        //        using (var db = new vt_LHRLAEntities())
        //        {
        //            lst = db.tbl_Case.Where(e => e.ID == ID).ToList();
        //        }
        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}




        #endregion
    }
}