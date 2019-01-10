using LHRLA.Core.Helpers;
using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LHRLA.Controllers
{
    [SessionAttribute]
    public class CaseStatusController : Controller
    {
        // GET: CaseStatus
        [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess();
            var list = ctd.GetAllCaseStatus();
            //ViewBag.City = null;
            return View(list);
        }


        public ActionResult AddUpdateCaseStatus(tbl_Case_Status request)
        {

            LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess();
            var Code = request.Code.ToLower().Trim();
            var CaseStatusData = ctd.GetCaseStatusbyIDOnUpdate(request.ID,Code);
            var CaseStatusCode = CaseStatusData.Select(o => o.Code).FirstOrDefault();
            var CaseStatusExistingData = ctd.GetCaseStatusbyIDOfExistingData(request.ID, Code);
            var CaseStatusExistingCode = CaseStatusExistingData.Select(o => o.Code).FirstOrDefault();
            var flag = true;

            if (request.ID > 0)
            {
                if (CaseStatusCode != Code)
                {
                    flag = ctd.UpdateCaseStatus(request);

                }

                else if (CaseStatusExistingCode == Code)
                {
                    flag = ctd.UpdateCaseStatus(request);

                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseStatus") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = ctd.CheckDuplicateData(Code);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseStatus") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = ctd.AddCaseStatus(request);
                }
            }
           // var flag = request.ID > 0 ? ctd.UpdateCaseStatus(request) : ctd.AddCaseStatus(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseStatus") : null }, JsonRequestBehavior.AllowGet);
        }
        [AuthOp]
        public ActionResult Index(int? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Caseid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseStatusDataAccess();
            var flag = ctd.GetCaseStatusbyID(Caseid).FirstOrDefault();
            return View(flag);
        }
    }
}