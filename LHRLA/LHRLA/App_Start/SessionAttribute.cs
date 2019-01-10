using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LHRLA.Core.Helpers
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["User"] == null && HttpContext.Current.Session["RoleID"] == null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { Error = "SessionExpire" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    //filterContext.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
                    filterContext.Result = new RedirectResult("~/Login");
                }

                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
