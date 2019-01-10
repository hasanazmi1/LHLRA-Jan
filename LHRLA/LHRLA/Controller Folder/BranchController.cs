using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LHRLA.DAL;
using LHRLA.Core.Helpers;

namespace LHRLA.Controllers
{
    [SessionAttribute]
    public class BranchController : Controller
    {
        // GET: BrachesSetup

      [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.BranchDataAccess bda = new LHRLA.DAL.DataAccessClasses.BranchDataAccess();
            var list = bda.GetAllBranches();
            //ViewBag.City = null;
            return View(list);
        }

       
        public ActionResult AddUpdateBranch(tbl_Branch request)
        {
          
            LHRLA.DAL.DataAccessClasses.BranchDataAccess bda = new LHRLA.DAL.DataAccessClasses.BranchDataAccess();
            var Name = request.Name.ToLower().Trim();
            var BranchDataForExistingName = bda.GetBranchbyNameID(request.ID, Name);
            var BranchData = bda.GetBranchbyIDOnUpdate(request.ID, Name);
            var BranchName = BranchData.Select(o => o.Name).FirstOrDefault();
            var BranchExistingName = BranchDataForExistingName.Select(o => o.Name).FirstOrDefault();


            var flag = true;
            if (request.ID > 0)
            {
                if (BranchExistingName == Name)
                {
                    flag = bda.UpdateBranch(request);

                }
                else if (BranchName != Name)
                {
                    flag = bda.UpdateBranch(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Branch") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = bda.CheckDuplicateData(Name);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "Branch") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = bda.AddBranch(request);
                }
            }

            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("List", "Branch") : null }, JsonRequestBehavior.AllowGet);

        }

       [AuthOp]
        public ActionResult Index(int ? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Branchid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.BranchDataAccess bda = new LHRLA.DAL.DataAccessClasses.BranchDataAccess();
            var flag = bda.GetBranchbyID(Branchid).FirstOrDefault();
            return View(flag);
        }
        
    }
}