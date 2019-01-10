using LHRLA.Core.Helpers;
using LHRLA.Core.Methods;
using LHRLA.Core.ViewModel;
using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LHRLA.Controllers
{
    public class CaseController : Controller
    {
        // GET: CaseScreen

        #region Counselling
        public ActionResult Counselling(int? id)
        {
            int CaseId = 0;
            if (id != null)
            {
                CaseId = int.Parse(id.ToString());
            }
            ViewBag.LinkedCase = CaseId;
            return View();
        }
        public ActionResult AddCounselling(tbl_Councelling_Sessions sess)
        {
            var flag = true;
            
            if (sess.ID > 0)//update
            {
                flag = new LHRLA.DAL.DataAccessClasses.CouncellingSessionsDataAccess().UpdateCouncellingSessions(sess);
            }
            else //add counselling session
            {
                //Get Current User ID for counselling session

                flag = new LHRLA.DAL.DataAccessClasses.CouncellingSessionsDataAccess().AddCouncellingSessions(sess);
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Counselling", "Case") : null }, JsonRequestBehavior.AllowGet);
        }

        #endregion

       // [AuthOp]
        public ActionResult List()
        {
            
            //LHRLA.DAL.DataAccessClasses.CaseDataAccess cda = new LHRLA.DAL.DataAccessClasses.CaseDataAccess();
            var list = CaseMethods.GetStaticCaseDetailsList();
            //ViewBag.City = null;
            return View(list);
        }

        #region Case Add
       // [AuthOp]
        public ActionResult Index(int? id)
        {
            //bind dynamic fields
            ViewBag.CaseFields = CaseMethods.GetCaseFields();
            //dynamic fields options
            ViewBag.FieldOptions = new LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess().GetAllActiveCaseFieldsOptions();

            //case registeration type
            ViewBag.RegisterationType = new LHRLA.DAL.CaseRegisterationTypesDataAccess().GetAllActiveCaseRegisterationTypes();
            //case tags
            ViewBag.Tags = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess().GetAllActiveTagsSetup();
            //case Sub Types
            ViewBag.SubTypes = new LHRLA.DAL.DataAccessClasses.CaseSubTypesDataAccess().GetAllActiveCaseSubTypes();
            //case Types
            ViewBag.caseTypes = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllActiveCaseTypes();
            //Ref Agency
            ViewBag.RefAgency = new LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess().GetAllReferralAgency();

            ViewBag.List = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllCaseTypes().ToList();

            int LinkedCase = 0;
            if (id != null)
            {
                LinkedCase = int.Parse(id.ToString());
            }
            ViewBag.LinkedCase = LinkedCase;
            return View();
        }

        public ActionResult AddCaseData(tbl_Case CaseStaticData, string[] RefAgency, string[] Tags, List<tbl_Case_Data> CaseDynamicData)
        {
            var flag = true;
            int CaseId = 0;
            
            if (CaseStaticData != null)
            {
                //set user and counselor ID
                if (Session["UserId"] != null)
                {
                    int Current_User = int.Parse(Session["UserId"].ToString());
                    CaseStaticData.UserID = Current_User;
                    CaseStaticData.CounselorId = Current_User;
                }
                else
                {
                    //redirect if the Current user is not eligible for approval
                    return RedirectToAction("Index", "Home");
                }
            
                //static data
                CaseStaticData.Is_Submitted = true;
                CaseStaticData.Approval_Level = 0;
                if (CaseStaticData.Linked_Case_ID == 0)
                {
                    CaseStaticData.Linked_Case_ID = null;
                }
                //Define initial case status
                int StatusID = 0;
                bool IsParsed=int.TryParse(ConfigurationManager.AppSettings["StatusID"].ToString(), out StatusID);
                if (IsParsed)
                {
                    CaseStaticData.Current_Status_ID = StatusID;
                }
                CaseId = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().AddCase(CaseStaticData);
                if (CaseId > 0)
                {
                    //add case tags
                    if (Tags != null)
                    {
                        LHRLA.DAL.DataAccessClasses.CaseTagsDataAccess ctda = new LHRLA.DAL.DataAccessClasses.CaseTagsDataAccess();
                        //remove existing tags
                        List<tbl_Case_Tags> lstTags = new List<DAL.tbl_Case_Tags>();
                        for (int i = 0; i < Tags.Count(); i++)
                        {
                            tbl_Case_Tags tag = new tbl_Case_Tags();
                            tag.Case_ID = CaseId;
                            tag.Tag_ID = int.Parse(Tags[i]);
                            lstTags.Add(tag);
                        }
                        bool IsAdded = ctda.AddAllCaseTags(lstTags);
                    }
                    if (RefAgency != null)
                    {
                        //add Ref Agency
                        LHRLA.DAL.CaseReferralDataAccess ctda = new LHRLA.DAL.CaseReferralDataAccess();
                        List<tbl_Case_Referral> lstTags = new List<DAL.tbl_Case_Referral>();
                        for (int i = 0; i < Tags.Count(); i++)
                        {
                            tbl_Case_Referral tag = new tbl_Case_Referral();
                            tag.Case_ID = CaseId;
                            tag.Agency_ID = int.Parse(Tags[i]);
                            lstTags.Add(tag);
                        }
                        bool IsAdded = ctda.AddAllCaseReferral(lstTags);
                    }
                }
            }
            if (CaseDynamicData != null && CaseId > 0)
            {
                for (int i = 0; i < CaseDynamicData.Count; i++)
                {
                    CaseDynamicData[i].Case_ID = CaseId;
                }
                flag = new LHRLA.DAL.DataAccessClasses.CaseDataDataAccess().AddAllCaseData(CaseDynamicData);
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Permission", "User") : null }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region case update
       // [AuthOp]
        public ActionResult Update(int? id)
        {
            // var case_types = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllActiveCaseTypes();
            //Get the Current Static Data
            //ViewBag.case_static_details = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCasebyID(int.Parse(id.ToString()));
            var case_static_details1 = CaseMethods.GetStaticCaseDetails(int.Parse(id.ToString()));
            ViewBag.case_static_details = case_static_details1;
            //get the dynamic data against case ID
            ViewBag.CaseDynamicData = CaseMethods.GetDynamicCaseData(int.Parse(id.ToString()));

            //bind dynamic fields
            ViewBag.CaseFields = CaseMethods.GetCaseFields();
            //dynamic fields options
            ViewBag.FieldOptions = new LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess().GetAllActiveCaseFieldsOptions();

            //case registeration type
            ViewBag.RegisterationType = new LHRLA.DAL.CaseRegisterationTypesDataAccess().GetAllActiveCaseRegisterationTypes();
            //case tags
            ViewBag.Tags = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess().GetAllActiveTagsSetup();
            //case Sub Types
            ViewBag.SubTypes = new LHRLA.DAL.DataAccessClasses.CaseSubTypesDataAccess().GetAllActiveCaseSubTypes();
            //case Types
            ViewBag.caseTypes = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllActiveCaseTypes();
            //Ref Agency
            ViewBag.RefAgency = new LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess().GetAllReferralAgency();
            //Case Sub Type List
            ViewBag.List = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetAllCaseTypes().ToList();
            //Case Main Type List
            ViewBag.CaseMainTypeList = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess().GetCaseTypesbyCaseSubTypeID(case_static_details1.SubTypeId);
            //Referrals
            ViewBag.CaseReferrals = new LHRLA.DAL.CaseReferralDataAccess().GetCaseReferralbyCaseId(int.Parse(id.ToString()));
            //Tags
            ViewBag.CaseTags = new LHRLA.DAL.DataAccessClasses.CaseTagsDataAccess().GetCaseTagsbyCaseID(int.Parse(id.ToString()));
            return View();
        }

        public ActionResult UpdateCaseData(tbl_case_temp CaseStaticData, string[] RefAgency, string[] Tags, List<tbl_Case_Data_temp> CaseDynamicData)
        {
            var flag = true;
            int CaseId = 0;
            if (CaseStaticData != null)
            {
                //Add Log
                tbl_Case_History_Log log = new DAL.tbl_Case_History_Log();
                log.Case_ID = CaseStaticData.Case_ID;
                
                int LogId = new LHRLA.DAL.CaseHistoryLogDataAccess().AddCaseHistoryLog(log);
                if (LogId > 0)
                {
                    CaseId = int.Parse(CaseStaticData.Case_ID.ToString());
                    //static data
                    CaseStaticData.CaseHistoryLogID = LogId;
                    bool IsAdded = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().AddCaseTemp(CaseStaticData);
                    if (IsAdded)
                    {
                        //add case tags
                        if (Tags != null)
                        {
                            LHRLA.DAL.DataAccessClasses.CaseTagsDataAccess ctda = new LHRLA.DAL.DataAccessClasses.CaseTagsDataAccess();
                            //remove existing tags
                            bool IsDeleted = ctda.DeleteCaseTags(CaseId);
                            if (IsDeleted)
                            {
                                List<tbl_Case_Tags> lstTags = new List<DAL.tbl_Case_Tags>();
                                for (int i = 0; i < Tags.Count(); i++)
                                {
                                    tbl_Case_Tags tag = new tbl_Case_Tags();
                                    tag.Case_ID = int.Parse(log.Case_ID.ToString());
                                    tag.Tag_ID = int.Parse(Tags[i]);
                                    lstTags.Add(tag);
                                }
                                bool IsTagAdded = ctda.AddAllCaseTags(lstTags);
                            }
                        }
                        if (RefAgency != null)
                        {
                            //add Ref Agency
                            LHRLA.DAL.CaseReferralDataAccess ctda = new LHRLA.DAL.CaseReferralDataAccess();
                            //remove existing 
                            bool IsDeleted = ctda.DeleteCaseReferral(CaseId);
                            if (IsDeleted)
                            {
                                List<tbl_Case_Referral> lstTags = new List<DAL.tbl_Case_Referral>();
                                for (int i = 0; i < Tags.Count(); i++)
                                {
                                    tbl_Case_Referral tag = new tbl_Case_Referral();
                                    tag.Case_ID = int.Parse(log.Case_ID.ToString());
                                    tag.Agency_ID = int.Parse(Tags[i]);
                                    lstTags.Add(tag);
                                }
                                bool IsRefAdded = ctda.AddAllCaseReferral(lstTags);
                            }
                        }
                    }

                    if (CaseDynamicData != null && CaseId > 0)
                    {
                        for (int i = 0; i < CaseDynamicData.Count; i++)
                        {
                            CaseDynamicData[i].Case_ID = CaseId;
                            CaseDynamicData[i].CaseHistoryLogID = LogId;
                        }
                        flag = new LHRLA.DAL.DataAccessClasses.CaseDataTempDataAccess().AddAllCaseTempData(CaseDynamicData);
                    }
                    if (flag == true)
                    {
                        //Update Case Approval Level
                        flag = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().UpdateApproval(int.Parse(log.Case_ID.ToString()));
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Permission", "User") : null }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        public JsonResult GetCase(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            return Json(new SelectList(ctd.GetCaseTypesbyCaseSubTypeID(ID), "ID", "Type"));
        }



        #region [CaseTags]
        [AuthOp]
        public ActionResult CaseTagList()
        {

            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess tsd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var list = tsd.GetAllTagsSetup();
            //ViewBag.City = null;
            return View(list);
        }

        public ActionResult AddUpdateCaseTags(tbl_Tags_Setup request)
        {

            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess tsd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var flag = request.ID > 0 ? tsd.UpdateTagsSetup(request) : tsd.AddTagsSetup(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("CaseTagList", "CaseScreen") : null }, JsonRequestBehavior.AllowGet);
        }
        [AuthOp]
        public ActionResult CaseTag(int ? id)
        {
            if (id == 0)
            {
                return View();

            }
            int TagId = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess tsd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var flag = tsd.GetTagsSetupbyID(TagId).FirstOrDefault();
            return View(flag);
        }

        #endregion

        #region Followup/Status/Counselor Update

        [AuthOp]
        public ActionResult FollowupUpdate(int? id)
        {
            tbl_Case c = new tbl_Case();
            c = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCasebyID(int.Parse(id.ToString()));
            return View(c);
        }
        [AuthOp]
        public ActionResult CaseTransfer(int? id)
        {
            tbl_Case c = new tbl_Case();
            c = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCasebyID(int.Parse(id.ToString()));
            ViewBag.Counselors = new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetAllActiveUsers();
            string Counselor = "";
            if (c.CounselorId != null)
            {
                Counselor = new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetUserbyID(int.Parse(c.CounselorId.ToString())).FirstOrDefault().User_Name;
            }
            ViewBag.CurrentCounselor = Counselor;
            return View(c);
        }
        [AuthOp]
        public ActionResult StatusUpdate(int? id)
        {
            tbl_Case c = new tbl_Case();
            c = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCasebyID(int.Parse(id.ToString()));
            ViewBag.StatusList = new LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess().GetAllActiveCaseStatus();
            return View(c);
        }
        [AuthOp]
        public ActionResult CaseHistory(int? id)
        {
            tbl_Case_History_Log c = new tbl_Case_History_Log();
            c = new LHRLA.DAL.CaseHistoryLogDataAccess().GetCaseHistoryLogsbyCaseID(int.Parse(id.ToString()));
            tbl_Case case_ = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCasebyID(int.Parse(c.Case_ID.ToString()));
            if (case_.Approval_Level ==0)
            {
                //redirect if the case is not pending for approval
                return RedirectToAction("Index", "Home");
            }
            //check if the current user is elegibile for approval
            int Supervisor_ID = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().GetCaseSupervisor(case_.ID, case_.Approval_Level);
            //Get Current User
            if (Session["UserId"] != null)
            {
                if (Supervisor_ID > 0)
                {
                    int Current_User = int.Parse(Session["UserId"].ToString());
                    if (Supervisor_ID != Current_User || Supervisor_ID==0)
                    {
                        //redirect if the Current user is not eligible for approval
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            tbl_case_temp case_temp = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().GetCaseTempbyLogID(c.ID);
            ViewBag.CaseDetails = case_;
            List<CaseDataVM> cd = CaseMethods.GetDynamicCaseData(int.Parse(c.Case_ID.ToString()));
            List<CaseDataVM> cdt = CaseMethods.GetTempDynamicCaseData(int.Parse(c.Case_ID.ToString()),c.ID);
            ViewBag.CaseHistoryData = CaseMethods.CaseDetailsComparision(case_, case_temp, cd, cdt);
            ViewBag.CaseDynamicFieldsDetails = cd;
            ViewBag.CaseDynamicFieldsDetailsNew = cdt;
            return View(c);
        }

         
        public ActionResult AddFollowUpdate(DAL.tbl_case_temp request,string FD)
        {
            var flag = true;
            if (request != null)
            {
                tbl_Case_History_Log log = new tbl_Case_History_Log();
                log.Case_ID = request.Case_ID;
                int HistoryId = new LHRLA.DAL.CaseHistoryLogDataAccess().CreateCaseHistoryLog(log);
                if (HistoryId > 0)
                {
                    request.CaseHistoryLogID = HistoryId;
                    DateTime dt = new DateTime(int.Parse(FD.Substring(6, 4)), int.Parse(FD.Substring(0, 2)), int.Parse(FD.Substring(3, 2)));
                    request.Followup_Date = dt;
                    flag = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().AddCaseTemp(request);
                    if (flag == true)
                    {
                        //Update Case Approval Level
                        flag = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().UpdateApproval(int.Parse(log.Case_ID.ToString()));
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Case") : null }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCaseTransfer(DAL.tbl_case_temp request)
        {
            var flag = true;
            if (request != null)
            {
                tbl_Case_History_Log log = new tbl_Case_History_Log();
                log.Case_ID = request.Case_ID;
                int HistoryId = new LHRLA.DAL.CaseHistoryLogDataAccess().CreateCaseHistoryLog(log);
                if (HistoryId > 0)
                {
                    request.CaseHistoryLogID = HistoryId;
                    flag = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().AddCaseTemp(request);
                    if (flag == true)
                    {
                        //Update Case Approval Level
                        flag = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().UpdateApproval(int.Parse(log.Case_ID.ToString()));
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Case") : null }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddStatusUpdate(DAL.tbl_case_temp request)
        {
            var flag = true;
            if (request != null)
            {
                tbl_Case_History_Log log = new tbl_Case_History_Log();
                log.Case_ID = request.Case_ID;
                int HistoryId = new LHRLA.DAL.CaseHistoryLogDataAccess().CreateCaseHistoryLog(log);
                if (HistoryId > 0)
                {
                    request.CaseHistoryLogID = HistoryId;
                    flag = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().AddCaseTemp(request);
                    if (flag == true)
                    {
                        //Update Case Approval Level
                        flag = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().UpdateApproval(int.Parse(log.Case_ID.ToString()));
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Case") : null }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Approve/Reject
        
        public ActionResult ApproveCaseHistory(int logId, int CaseId)
        {
            var flag = true;
            //if required level of approval has been achieved then the data should be updated
            tbl_case_temp case_temp = new LHRLA.DAL.DataAccessClasses.CaseTempDataAccess().GetCaseTempbyLogID(logId);
            LHRLA.DAL.DataAccessClasses.CaseDataAccess cda = new LHRLA.DAL.DataAccessClasses.CaseDataAccess();
            tbl_Case case_ = cda.GetCasebyID(CaseId);
            //for followup update
            if (case_temp.Followup_Date != null || case_temp.CounselorId != null)
            {
                //followup and counselor update requires two level of approval
                if (case_.Approval_Level == 1)//esclate to next level without data ammendment
                {
                   flag= cda.UpdateApproval(CaseId);
                }
                else if (case_.Approval_Level == 2)//setting the case state to zero as well as updating the data
                {
                    if (case_temp.Followup_Date != null)
                    {
                        flag = cda.UpdateCaseFollowup(CaseId, (DateTime)case_temp.Followup_Date);
                    }
                    else
                    {
                        flag = cda.UpdateCaseCounseller(CaseId, (int)case_temp.CounselorId);
                    }
                }
            }
            else if (case_temp.Current_Status_ID != null)
            {
                flag = cda.UpdateCaseStatus(CaseId, (int)case_temp.Current_Status_ID);
            }
            else
            {
                //dynamic detals
                flag = new LHRLA.DAL.DataAccessClasses.CaseDataDataAccess().UpdateCaseDataOnApproval(CaseId, logId);
                //static details
                flag = cda.UpdateCaseDetailsOnApproval(case_temp); 
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Case") : null }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RejectCaseHistory(int logId,int CaseId)
        {
            //will be setting the case status as 0 
            var flag = true;
            flag = new LHRLA.DAL.DataAccessClasses.CaseDataAccess().MarkRejection(CaseId);
            int UserId = 1;
            string Comments = "";
            flag = new LHRLA.DAL.CaseHistoryLogDataAccess().UpdateCaseHistoryApproval(logId,UserId,Comments);
            //check if email alert sending is required
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Case") : null }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}