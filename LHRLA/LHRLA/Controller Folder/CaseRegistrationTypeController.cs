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
    public class CaseRegistrationTypeController : Controller
    {
        // GET: CaseRegistrationType
       [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.CaseRegisterationTypesDataAccess crt = new LHRLA.DAL.CaseRegisterationTypesDataAccess();
            var list = crt.GetAllCaseRegisterationTypes();
            //ViewBag.City = null;
            return View(list);
        }


        public ActionResult AddUpdateCaseRegisterationTypes(tbl_Case_Registeration_Types request)
        {

            LHRLA.DAL.CaseRegisterationTypesDataAccess crt = new LHRLA.DAL.CaseRegisterationTypesDataAccess();
            string Type = request.Type.ToLower().Trim();
            var CaseData = crt.GetCaseRegisterationTypesbyIDOnUpdate(request.ID, Type);
            var CaseType = CaseData.Select(o => o.Type).FirstOrDefault();
            var CaseExistingData = crt.GetCaseRegisterationTypesOfExistingData(request.ID, Type);
            var CaseExistingType = CaseExistingData.Select(o => o.Type).FirstOrDefault();
            var flag = true;
            if (request.ID > 0)
            {
                if (CaseType != Type)
                {
                    flag = crt.UpdateCaseRegisterationTypes(request);

                }
                else if (CaseExistingType == Type)
                {
                    flag = crt.UpdateCaseRegisterationTypes(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseRegistrationType") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = crt.CheckDuplicateData(Type);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseRegistrationType") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = crt.AddCaseRegisterationTypes(request);
                }
            }



           // var flag = request.ID > 0 ? crt.UpdateCaseRegisterationTypes(request) : crt.AddCaseRegisterationTypes(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseRegistrationType") : null }, JsonRequestBehavior.AllowGet);
        }

        [AuthOp]
        public ActionResult Index(int? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Regid = Convert.ToInt32(id);
            LHRLA.DAL.CaseRegisterationTypesDataAccess crt = new LHRLA.DAL.CaseRegisterationTypesDataAccess();
            var flag = crt.GetCaseRegisterationTypesbyID(Regid).FirstOrDefault();
            return View(flag);
        }
    }
}