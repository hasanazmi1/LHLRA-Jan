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
    public class RoleController : Controller
    {
        // GET: BrachesSetup
       [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.RoleDataAccess rda = new LHRLA.DAL.DataAccessClasses.RoleDataAccess();
            var list = rda.GetAllRolees();
            //ViewBag.City = null;
            return View(list);
        }


        public ActionResult AddUpdateRole(tbl_Role request)
        {

            LHRLA.DAL.DataAccessClasses.RoleDataAccess rda = new LHRLA.DAL.DataAccessClasses.RoleDataAccess();
            var Name = request.Name.ToLower().Trim();
            var RoleExistData = rda.GetRolebyIDOfExistingData(request.ID, Name);
            var NameExistValue = RoleExistData.Select(o => o.Name).FirstOrDefault();
            var RoleData = rda.GetRolebyIDName(request.ID, Name);
            var NameValue = RoleData.Select(o => o.Name).FirstOrDefault();
            var flag = true;
            if (request.ID > 0)
            {
                if (NameValue != Name)
                {
                    flag = rda.UpdateRole(request);

                }
                else if (NameExistValue == Name)
                {
                    flag = rda.UpdateRole(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = rda.CheckDuplicateData(Name);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = rda.AddRole(request);
                }
            }


          //  var flag = request.ID > 0 ? rda.UpdateRole(request) : rda.AddRole(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "Role") : null }, JsonRequestBehavior.AllowGet);
        }

      [AuthOp]
        public ActionResult Index(int? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Roleid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.RoleDataAccess rda = new LHRLA.DAL.DataAccessClasses.RoleDataAccess();
            var flag = rda.GetRolebyID(Roleid).FirstOrDefault();
            return View(flag);
        }
    }
}