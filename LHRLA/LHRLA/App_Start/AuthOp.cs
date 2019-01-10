using LHRLA.LHRLA.DAL.DataAccessClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LHRLA.Core.Helpers
{
    public class AuthOp : ActionFilterAttribute
    {
        public string[] RoleTitle { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var getRoleTitle = HttpContext.Current.Session["RoleID"];
            var getUserId = HttpContext.Current.Session["User"];
            var url = filterContext.HttpContext.Request.Url.AbsolutePath;

            url = url.Substring(url.Length - 1, 1).Contains("/") ? url : $"{url}/";
            // url = url.Substring(0, 1).Contains("/") ? url : $"{url}/";
            if (!new RolePagesDataAccess().UserPermission(Convert.ToInt32(getRoleTitle), url))
            {
                filterContext.Result = RedirectToCustomPage();//RedirectToError(); //bypassing permissions during testing
                filterContext.Result.ExecuteResult(filterContext);
            }

            //if (!RoleTitle.Contains(getRoleTitle))
            //{
            //    filterContext.Result = RedirectToCustomPage();//RedirectToError();
            //    filterContext.Result.ExecuteResult(filterContext);
            //}

            base.OnActionExecuting(filterContext);
        }

        public RedirectToRouteResult RedirectToError()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Base",
                action = "Error"
            }));
        }

        public RedirectToRouteResult RedirectToCustomPage()
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                controller = "Home",
                action = "Index"
            }));

        }

    }
}