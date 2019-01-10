using LHRLA.Core.Helpers;
using LHRLA.DAL;
using LHRLA.LHRLA.Core.ApplicationHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Security;

namespace LHRLA.Controllers
{
    public class LoginController : Controller
    {
        vt_LHRLAEntities db =new vt_LHRLAEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            string EncryptedPassword = new vt_Common().Encrypt(Password);
            var dt = new LHRLA.DAL.DataAccessClasses.UserDataAccess().CheckUser(Email, EncryptedPassword);
            var InactiveUser = dt.Select(o => o.Is_Active).FirstOrDefault();
            var UserID = dt.Select(o => o.ID).FirstOrDefault();
            var RoleID = dt.Select(o => o.Role_ID).FirstOrDefault();
           // Core.ViewModel.MenuVM _login = new Core.ViewModel.MenuVM();
            try
            {
                if (dt != null)
                {
                    if (InactiveUser == true)
                    {
                        Session["UserID"] = UserID;
                        Session["User"] = Email;
                        Session["RoleID"] = RoleID;
                        Core.ViewModel.UserVM _loginCredentials = db.tbl_User.Where(x => x.ID == UserID).Select(x => new Core.ViewModel.UserVM
                        {
                            ID = x.ID,
                            User_Name = x.User_Name,
                            Role_ID = x.Role_ID,
                            RoleTitle = x.tbl_Role.Name
                        }).FirstOrDefault();  // Get the login user details and bind it to LoginModels class  
                        List<Core.ViewModel.MenuVM> _menus = db.tbl_Role_Pages.Where(x => x.Role_ID == _loginCredentials.Role_ID && x.tbl_Pages.Is_Active == true && x.tbl_Pages.MenuDisplay == true).Select(x => new Core.ViewModel.MenuVM
                        {
                            SectionID = x.tbl_Pages.Section_ID,
                            Section = x.tbl_Pages.tbl_Section.Title,
                            PageID = x.tbl_Pages.ID,
                            Page = x.tbl_Pages.Title,
                            URL = x.tbl_Pages.URL,
                            //ActionName = x.Action,
                            // RoleId = x.RoleId,
                            //  RoleName = x.tblRole.Roles
                        }).ToList(); //Get the Menu details from entity and bind it in MenuModels list.  
                        FormsAuthentication.SetAuthCookie(_loginCredentials.Email, false); // set the formauthentication cookie  
                                                                                           //  Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session  
                        Session["MenuMaster"] = _menus; //Bind the _menus list to MenuMaster session  
                        Session["UserName"] = _loginCredentials.Email;
                        return Redirect("/Home");
                        // return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        TempData["Error"] = "You are Inactivated,Please contact to Administrator";
                        //  Debug.WriteLine(FlattenException(e));
                        return Redirect("/Login");
                    }

                }

                //

            }
            catch (Exception ex)

            {
                TempData["Error"] = "User name or password incorrect";
                //  Debug.WriteLine(FlattenException(e));
                return Redirect("/Login");

            }

            TempData["Error"] = "User name or password incorrect";
            return Redirect("/Login");

        }



        public ActionResult Registeration(string fullname, string email, string password, string rpassword)
        {
            tbl_User row = new tbl_User();
            string EncryptedPassword = new vt_Common().Encrypt(rpassword);
            try
            {

                row.User_Name = fullname;
                row.Email = email;
                row.User_Password = EncryptedPassword;
                var dt = new LHRLA.DAL.DataAccessClasses.UserDataAccess().AddUser(row);
                TempData["Error"] = "You registered sucessfully";
                return RedirectToAction("Index", "Login");


            }
            catch (Exception ex)

            {
                throw ex;

            }
            return RedirectToAction("Index", "Login");


        }
        public ActionResult ForgotPasswordRecovery(string m_email)
        {
            try
            {

                var dt = new LHRLA.DAL.DataAccessClasses.UserDataAccess().CheckUserEmail(m_email).FirstOrDefault();
                if (dt != null)
                {
                    tbl_User row = new LHRLA.DAL.DataAccessClasses.UserDataAccess().GetUserbyID(Convert.ToInt32(dt.ID)).FirstOrDefault();
                    string decrypt = new vt_Common().Decrypt(row.User_Password);
                    //string body = new EmailFormat().ResetEmailFormat1;
                    //body = body.Replace("{{ResetEmail}}", decrypt);
                    //bool isSend = vt_Common.EmailformatSendVisitor(m_email, "", "Forgot Password", body);
                    TempData["ErrorForgot"] = "Password has been sent to your email."; TempData["ErrorForgot"] = "Email has been sent, please check";
                    return RedirectToAction("ForgotPassword", "Login");
                }
                else
                {
                    TempData["ErrorForgot"] = "Entered Email doesn't exists";
                    return RedirectToAction("ForgotPassword", "Login");

                }

            }
            catch (Exception ex)

            {
                throw ex;

            }
            return RedirectToAction("ForgotPassword", "Login");


        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Session["User"] = null;
            Session["RoleID"] = null;
            Session["UserID"] = null;
            return Redirect("/Login");
        }
    }




    //public ActionResult Index()
    //{
    //    if (ApplicationHelper.IsUserLogin())
    //    {
    //        return RedirectToAction("Index", "Home");
    //    }
    //    else
    //    {
    //        return RedirectToAction("Index", "Login");
    //    }
    //}



    /*[AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }*/

    //[AllowAnonymous]
    //public ActionResult Login()
    //{
    //    if (ApplicationHelper.IsUserLogin())
    //    {
    //        return RedirectToAction("Index", "Home");
    //    }
    //    else
    //    {
    //        string CookieUserName = ApplicationHelper.GetCookie(ApplicationHelper.Cookie_UserName);
    //        string CookiePassword = ApplicationHelper.GetCookie(ApplicationHelper.Cookie_User_Password);
    //        if (!string.IsNullOrWhiteSpace(CookieUserName) && !string.IsNullOrWhiteSpace(CookiePassword))
    //        {
    //            ViewBag.CookieUserName = CookieUserName;
    //            ViewBag.CookiePassword = CookiePassword;
    //        }
    //        return View();
    //    }
    //}
    //[AllowAnonymous]
    //[HttpPost]
    //public JsonResult Login(string Email, string Password, string remember_me)
    //{
    //    ApplicationHelper.AjaxResponse AjaxResponse = new ApplicationHelper.AjaxResponse();
    //    AjaxResponse.Type = "M";
    //    AjaxResponse.Success = false;
    //    AjaxResponse.Message = "Invalid credentials";
    //    try
    //    {
    //        if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
    //        {
    //            string LoginEncryptPasswordValue = vt_Common.Encrypt(Password);
    //            // string decrypt = vt_Common.Decrypt(password);
    //             var dt = new LHRLA.DAL.DataAccessClasses.UserDataAccess().CheckUser(Email, LoginEncryptPasswordValue);


    //                //todo: check user status, i.e. active/inactive, subscription status etc.
    //                ApplicationHelper.AddSession(ApplicationHelper.Session_User_Login, dt);

    //                if (!string.IsNullOrWhiteSpace(remember_me))
    //                {
    //                    ApplicationHelper.AddCookie(ApplicationHelper.Cookie_UserName, Email);
    //                    ApplicationHelper.AddCookie(ApplicationHelper.Cookie_User_Password, Password);
    //                }
    //                else
    //                {
    //                    ApplicationHelper.RemoveCookie(ApplicationHelper.Cookie_UserName);
    //                    ApplicationHelper.RemoveCookie(ApplicationHelper.Cookie_User_Password);
    //                }

    //                AjaxResponse.Success = true;
    //                AjaxResponse.Type = "M-T";
    //                AjaxResponse.Message = "Logged-in successfully";
    //                //AjaxResponse.TargetURL = ApplicationHelper.ConvertToWebURL(Request.Url, "Home/" + ApplicationHelper.PageIndex);
    //                AjaxResponse.TargetURL = "Home";
    //            }
    //            else
    //            {//invalid login attempt
    //                AjaxResponse.Message = "Invalid credentails";
    //            }


    //        return Json(AjaxResponse, "json");
    //    }
    //    catch (Exception ex)
    //    {
    //        AjaxResponse.Message = ex.Message;
    //        return Json(AjaxResponse, "json");
    //    }
    //}
}
