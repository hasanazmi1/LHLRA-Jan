using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LHRLA.LHRLA.DAL.DataAccessClasses
{
    public class CaseTempDataAccess
    {
        #region Insert
        public bool AddCaseTemp(tbl_case_temp row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    db.tbl_case_temp.Add(row);
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

        public bool UpdateCaseTemp(tbl_case_temp row)
        {

            try
            {
                using (var db = new vt_LHRLAEntities())
                {
                    tbl_case_temp val = new tbl_case_temp();
                    val = db.tbl_case_temp.Where(a => a.ID == row.ID).FirstOrDefault();
                    val.Case_ID = row.Case_ID;
                    val.CaseHistoryLogID = row.CaseHistoryLogID;
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
                    val.Branch_ID = row.Branch_ID;

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
        public List<tbl_case_temp> GetAllCaseTemp()
        {
            try
            {
                List<tbl_case_temp> lst = new List<tbl_case_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_case_temp.ToList();
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



        public tbl_case_temp GetCaseTempbyID(int ID)
        {
            try
            {
                tbl_case_temp lst = new tbl_case_temp();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_case_temp.Where(e => e.ID == ID).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public tbl_case_temp GetCaseTempbyLogID(int HistoryLogId)
        {
            try
            {
                tbl_case_temp lst = new tbl_case_temp();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_case_temp.Where(e => e.CaseHistoryLogID==HistoryLogId).FirstOrDefault();
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<tbl_case_temp> GetAllCaseTempbyCaseID(int ID)
        {
            try
            {
                List<tbl_case_temp> lst = new List<tbl_case_temp>();
                using (var db = new vt_LHRLAEntities())
                {
                    lst = db.tbl_case_temp.Where(e => e.Case_ID == ID).ToList();
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