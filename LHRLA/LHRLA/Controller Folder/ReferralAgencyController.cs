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
    public class ReferralAgencyController : Controller
    {
        // GET: ReferralAgency
       [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess rad = new LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess();
            var list = rad.GetAllReferralAgency();
            //ViewBag.City = null;
            return View(list);
        }


        public ActionResult AddUpdateReferralAgency(tbl_Referral_Agency request)
        {

            LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess rad = new LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess();
            var Name = request.Name.ToLower().Trim();
            var ReferalExistData = rad.GetReferralAgencybyIDOfExistingName(request.ID, Name);
            var NameExistValue = ReferalExistData.Select(o => o.Name).FirstOrDefault();
            var ReferalData = rad.GetReferralAgencybyIDName(request.ID, Name);
            var NameValue = ReferalData.Select(o => o.Name).FirstOrDefault();
            var flag = true;
            if (request.ID > 0)
            {
                if (NameValue != Name)
                {
                    flag = rad.UpdateReferralAgency(request);

                }
                else if (NameExistValue == Name)
                {
                    flag = rad.UpdateReferralAgency(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = rad.CheckDuplicateData(Name);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = rad.AddReferralAgency(request);
                }
            }

           // var flag = request.ID > 0 ? rad.UpdateReferralAgency(request) : rad.AddReferralAgency(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "ReferralAgency") : null }, JsonRequestBehavior.AllowGet);
        }

        [AuthOp]
        public ActionResult Index(int? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Refid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess rad = new LHRLA.DAL.DataAccessClasses.ReferralAgencyDataAccess();
            var flag = rad.GetReferralAgencybyID(Refid).FirstOrDefault();
            return View(flag);
        }
    }
}