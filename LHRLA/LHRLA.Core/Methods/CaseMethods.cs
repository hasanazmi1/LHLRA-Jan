using System;
using System.Collections.Generic;
using System.Linq;
using LHRLA.Core.ViewModel;
using LHRLA.DAL;


namespace LHRLA.Core.Methods
{
    public class CaseMethods
    {
        #region Case Fields
        public static List<CaseFieldsVM> GetCaseFields() 
        {
            try
            {
                List<CaseFieldsVM> lstFields = new List<ViewModel.CaseFieldsVM>();
                using (var db = new vt_LHRLAEntities())
                {
                    lstFields = (from f in db.tbl_Case_Fields
                                 join s in db.tbl_Case_Fields_Section on f.Case_Field_Section_ID equals s.ID
                                 where f.Is_Active == true
                                 select new CaseFieldsVM
                                 {
                                     ID = f.ID,
                                     Name = f.Name,
                                     Field_Type = f.Field_Type,
                                     Is_Active = f.Is_Active,
                                     Sequence_No = f.Sequence_No,
                                     Is_Mandatory = f.Is_Mandatory,
                                     Is_Visible_On_App = f.Is_Visible_On_App,
                                     Case_Field_Section_ID = f.Case_Field_Section_ID,
                                     Is_Encrypted = f.Is_Encrypted,
                                     Is_Hidden = f.Is_Hidden,
                                     SectionTitle = s.Name,
                                 }).ToList();
                }

                return lstFields;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        //getting the string of comparision of values for the approval screen
        #region Comparision
        public static CaseDataHistoryVM CaseDetailsComparision(tbl_Case case_static_old,tbl_case_temp case_static_new
            , List<CaseDataVM> case_dynamic_old, List<CaseDataVM> case_dynamic_new)
        {
            try
            {
                CaseDataHistoryVM data = new ViewModel.CaseDataHistoryVM();
                //followup date update
                if (case_static_old.Followup_Date != case_static_new.Followup_Date
                    &&case_static_new.Followup_Date!=null)
                {
                    data.Followup_Date = (DateTime)(case_static_old.Followup_Date);
                    data.New_Followup_Date = (DateTime)(case_static_new.Followup_Date);
                }//status update
                else if (case_static_old.Current_Status_ID != case_static_new.Current_Status_ID
                    &&case_static_new.Current_Status_ID!=null)
                {
                    List<tbl_Case_Status> lstStatus = new LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess().GetAllCaseStatus();
                    string Old_Status = lstStatus.Where(a => a.ID == case_static_old.Current_Status_ID).FirstOrDefault().Code;
                    string New_Status = lstStatus.Where(a => a.ID == case_static_new.Current_Status_ID).FirstOrDefault().Code;
                    data.Case_Status = Old_Status;
                    data.New_Case_Status = New_Status;
                }//counselor update
                else if (case_static_old.CounselorId != case_static_new.CounselorId
                    && case_static_new.CounselorId!=null)
                {
                    List<tbl_User> lstUsers= new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetAllUsers();
                    string Old_Counselor = lstUsers.Where(a => a.ID == case_static_old.CounselorId).FirstOrDefault().Name;
                    string New_Counselor = lstUsers.Where(a => a.ID == case_static_new.CounselorId).FirstOrDefault().Name;
                    data.Counselor = Old_Counselor;
                    data.New_Counselor = New_Counselor;

                }//data update
                else 
                {
                    if (case_static_old.Case_DateTime!=null && case_static_new.Case_DateTime != null)
                    {
                        data.Case_DateTime = (DateTime) (case_static_old.Case_DateTime);
                        data.New_Case_DateTime = (DateTime) (case_static_new.Case_DateTime);
                    }
                        List<tbl_Case_Types> lstCaseType = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllActiveCaseTypes();
                        data.Case_Type = lstCaseType.Where(a => a.ID == case_static_old.Case_Type_Id).FirstOrDefault().Type;
                        data.New_Case_Type = lstCaseType.Where(a => a.ID == case_static_new.Case_Type_Id).FirstOrDefault().Type;

                        data.Summary = case_static_old.Summary==null?"":case_static_old.Summary;
                        data.New_Summary = case_static_new.Summary==null?"":case_static_new.Summary;

                        data.Description = case_static_old.Description==null?"":case_static_old.Description;
                        data.New_Description = case_static_new.Description==null?"":case_static_new.Description;

                        List<tbl_Branch> lstBranch = new LHRLA.DAL.DataAccessClasses.BranchDataAccess().GetAllBranches();
                        data.Branch = lstBranch.Where(a => a.ID == case_static_old.Case_Type_Id).FirstOrDefault().Name;
                        data.New_Branch = lstBranch.Where(a => a.ID == case_static_new.Case_Type_Id).FirstOrDefault().Name;
                }

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region dynamic Case Data
        public static List<CaseDataVM> GetDynamicCaseData(int CaseId)
        {
           try
            {
                List<CaseDataVM> data = new List<CaseDataVM>(); ;
                using (var db = new vt_LHRLAEntities())
                {
                    data = (from f in db.tbl_Case_Fields
                                 join d in db.tbl_Case_Data on f.ID equals d.Case_Field_ID
                                 where d.Case_ID==CaseId 
                                 select new CaseDataVM
                                 {
                                    ID=d.ID,
                                    Case_Field_ID=d.Case_Field_ID,
                                    Case_ID=d.Case_ID,
                                    Field_Value=d.Field_Value,
                                    Description =d.Description,
                                    FieldTitle=f.Name,
                                 }).ToList();
                }
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static List<CaseDataVM> GetTempDynamicCaseData(int CaseId,int LogId)
        {
            try
            {
                List<CaseDataVM> data = new List<CaseDataVM>(); ;
                using (var db = new vt_LHRLAEntities())
                {
                    data = (from f in db.tbl_Case_Fields
                            join d in db.tbl_Case_Data_temp on f.ID equals d.Case_Field_ID
                            where d.Case_ID == CaseId && d.CaseHistoryLogID==LogId
                            select new CaseDataVM
                            {
                                ID = d.ID,
                                Case_Field_ID = d.Case_Field_ID,
                                Case_ID = d.Case_ID,
                                Field_Value = d.Field_Value,
                                Description = d.Description,
                                FieldTitle = f.Name
                            }).ToList();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region static data
        public static CaseVM GetStaticCaseDetails(int CaseId)
        {
            try
            {
                CaseVM val = new CaseVM();
                using (var db = new vt_LHRLAEntities())
                {
                    val = (from c in db.tbl_Case join r in db.tbl_Case_Registeration_Types on c.Case_Registeration_Type_Id equals r.ID
                           join s in db.tbl_Case_Status on c.Current_Status_ID equals s.ID 
                           join t in db.tbl_Case_Types on c.Case_Type_Id equals t.ID
                           join st in db.tbl_Case_Sub_Types on t.Case_Sub_Type_ID equals st.ID
                           where c.ID == CaseId
                                 select new CaseVM
                                 {
                                     ID = c.ID,
                                     Case_Code = c.Case_Code,
                                     Case_DateTime = c.Case_DateTime,
                                     Case_Type_Id = c.Case_Type_Id,
                                     Summary = c.Summary,
                                     Description = c.Description,
                                     Case_Registeration_Type_Id = c.Case_Registeration_Type_Id,
                                     Attachment_Count = c.Attachment_Count,
                                     Is_Submitted = c.Is_Submitted,
                                     Current_Status_ID = c.Current_Status_ID,
                                     Call_ID = c.Call_ID,
                                     Linked_Case_ID = c.Linked_Case_ID,
                                     Case_Reference_Person = c.Case_Reference_Person,
                                     Approval_Level = c.Approval_Level,
                                     Client_Name = c.Client_Name,
                                     Client_Contact = c.Client_Contact,
                                     Client_CNIC = c.Client_CNIC,
                                     Followup_Date = c.Followup_Date,
                                     Branch_ID = c.Branch_ID,
                                     UserID = c.UserID,
                                     CounselorId = c.CounselorId,
                                     SubTypeId= st.ID,
                                     Type=t.Type,
                                     RegisterationType=r.Type,
                                     Status=s.Code,
                                     Referral="",
                                     Tag="",
                                     
                                 }).FirstOrDefault();
                }
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CaseVM> GetStaticCaseDetailsList()
        {
            try
            {
                List<CaseVM> val = new List<CaseVM>();
                using (var db = new vt_LHRLAEntities())
                {
                    val = (from c in db.tbl_Case
                           join r in db.tbl_Case_Registeration_Types on c.Case_Registeration_Type_Id equals r.ID
                           join s in db.tbl_Case_Status on c.Current_Status_ID equals s.ID
                           join t in db.tbl_Case_Types on c.Case_Type_Id equals t.ID
                           join st in db.tbl_Case_Sub_Types on t.Case_Sub_Type_ID equals st.ID
                           
                           select new CaseVM
                           {
                               ID = c.ID,
                               Case_Code = c.Case_Code,
                               Case_DateTime = c.Case_DateTime,
                               Case_Type_Id = c.Case_Type_Id,
                               Summary = c.Summary,
                               Description = c.Description,
                               Case_Registeration_Type_Id = c.Case_Registeration_Type_Id,
                               Attachment_Count = c.Attachment_Count,
                               Is_Submitted = c.Is_Submitted,
                               Current_Status_ID = c.Current_Status_ID,
                               Call_ID = c.Call_ID,
                               Linked_Case_ID = c.Linked_Case_ID,
                               Case_Reference_Person = c.Case_Reference_Person,
                               Approval_Level = c.Approval_Level,
                               Client_Name = c.Client_Name,
                               Client_Contact = c.Client_Contact,
                               Client_CNIC = c.Client_CNIC,
                               Followup_Date = c.Followup_Date,
                               Branch_ID = c.Branch_ID,
                               UserID = c.UserID,
                               CounselorId = c.CounselorId,
                               SubTypeId = st.ID,
                               Type = t.Type,
                               RegisterationType = r.Type,
                               Status = s.Code,
                               Referral = "",
                               Tag = ""
                           }).ToList();
                }
                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
