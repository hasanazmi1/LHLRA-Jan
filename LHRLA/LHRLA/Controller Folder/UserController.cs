using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LHRLA.Core.Methods;
using LHRLA.Core.ViewModel;
using LHRLA.Core.Helpers;
using LHRLA.DAL;
using LHRLA.LHRLA.Core.ApplicationHelper;

namespace LHRLA.Controllers
{
    public class UserController : Controller
    {
        // GET: BrachesSetup
        
        public ActionResult Index(long? id)
        {
            if (id == 0)
            {
                return View();

            }
            string password = null;
            long Userid = Convert.ToInt64(id);
            LHRLA.DAL.DataAccessClasses.UserDataAccess uda = new LHRLA.DAL.DataAccessClasses.UserDataAccess();
            var flag = uda.GetUserbyID(Userid).FirstOrDefault();
            if (flag != null)
            { 
            if (flag.User_Password != null)
            { 
            password = flag.User_Password;
            flag.User_Password = new vt_Common().Decrypt(password);
            }
            }
            //bind role dropdown
            ViewBag.City = new LHRLA.DAL.DataAccessClasses.CityDataAccess().GetAllCity();
            ViewBag.Roles = new LHRLA.DAL.DataAccessClasses.RoleDataAccess().GetAllActiveRoles();
            ViewBag.Branch = new LHRLA.DAL.DataAccessClasses.BranchDataAccess().GetAllActiveBranches();
            ViewBag.Supervisor = new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetAllActiveUsers();
            if (id != null && id > 0)
            {
                ViewBag.UserBranches = new LHRLA.DAL.DataAccessClasses.UserBranchDataAccess().GetBranchbyUser(Userid);
            }
            else
            {
                ViewBag.UserBranches = null;
            }
            return View(flag);
        }
        public ActionResult AddUpdateUser(List<tbl_User_Branch> lstBranches, tbl_User request)
        {

            LHRLA.DAL.DataAccessClasses.UserDataAccess rda = new LHRLA.DAL.DataAccessClasses.UserDataAccess();
            LHRLA.DAL.DataAccessClasses.UserBranchDataAccess bda = new LHRLA.DAL.DataAccessClasses.UserBranchDataAccess();
            //add user
            string password = null;
            var flag = true;
            long UserId = request.ID;
            string email = request.Email.ToLower().Trim();
            var UserData = rda.GetUserbyIDOnUpdate(UserId,email);
            var UserEmail = UserData.Select(o => o.Email).FirstOrDefault();
            var UserExistingData = rda.GetUserbyIDName(UserId, email);
            var UserExistingEmail = UserExistingData.Select(o => o.Email).FirstOrDefault();

            if (request.ID > 0)
            {
                if (UserEmail != email)
                {
                    password = request.User_Password;
                    request.User_Password = new vt_Common().Encrypt(password);
                    flag = rda.UpdateUser(request);
                }
                else if (UserExistingEmail == email)
                {
                    password = request.User_Password;
                    request.User_Password = new vt_Common().Encrypt(password);
                    flag = rda.UpdateUser(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("list", "User") : null }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var CheckDuplicateEmail = rda.CheckUserEmail(email);
                if (CheckDuplicateEmail.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("list", "User") : null }, JsonRequestBehavior.AllowGet);

                 
                }
                else
                {
                    password = request.User_Password;
                    request.User_Password = new vt_Common().Encrypt(password);
                    UserId = rda.CreateUser(request);

                }

            }

            
            //add user branch
            if (UserId > 0 )
            {
                bool IsDeleted = bda.DeleteUserBranch(int.Parse(UserId.ToString()));
                if (IsDeleted)
                {
                    if (lstBranches!=null)
                    {
                        if (lstBranches.Count > 0)
                        {
                            flag = bda.AddMultipleUserBranch(lstBranches, int.Parse(UserId.ToString()));
                        }
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("list", "User") : null }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Permission()
        {
            //bind role dropdown
            ViewBag.Roles = new LHRLA.DAL.DataAccessClasses.RoleDataAccess().GetAllActiveRoles();
            //bind sections and pages
            var viewModel = new List<PageSectionVM>();
            viewModel = PagesMethods.GetAllSectionPages();

            return View(viewModel);
        }
        public ActionResult AddUpdateRolePages(List<DAL.tbl_Role_Pages> request)
        {
            var flag = true;
            if (request != null)
            {
                //delete existing permissions
                flag = new LHRLA.DAL.DataAccessClasses.RolePagesDataAccess().DeletePermissions(request.FirstOrDefault().Role_ID);
                //add new permissions
                flag = new LHRLA.DAL.DataAccessClasses.RolePagesDataAccess().AddMultipleRolePages(request);
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Permission", "User") : null }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult List()
        {
            var list = new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetAllUsers();

            return View(list);
        }

        
        public ActionResult GetRolePageDetails(int RoleId)
        {
            //mark pages assigned to the role
            var data = new LHRLA.DAL.DataAccessClasses.RolePagesDataAccess().GetRolePagesbyRoleID(RoleId);
            var rolePages= data.Select(e => new { Page_ID = e.Page_ID});

            return Json(new { IsSuccess = (rolePages == null) ? false : true, Response = new { RolePagesData = rolePages }, ErrorMessage = (rolePages == null) ? CustomMessages.NoData : string.Empty }, JsonRequestBehavior.AllowGet);
        }


    }
}