using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LHRLA.Core.Helpers
{
    public static class ApplicationHelper
    {

        #region "Website Value Helper"
        public const string Cookie_UserName = "Cookie_UserName";
        public const string Cookie_User_Password = "Cookie_User_Password";
        public const string Session_User_Login = "Session_User_Login";

        #endregion
        #region "Session Objects Helper"
        public static bool IsUserLogin()
        {
            bool ReturnCondition = false;
            if (GetSession(Session_User_Login) != null)
            {
                ReturnCondition = true;
            }
            return ReturnCondition;
        }

        #endregion

        #region "Session Helper"

        public static object GetSession(string _key)
        {
            object ReturnObject = null;
            var SessionObject = HttpContext.Current.Session[_key];
            if (SessionObject != null)
            {
                ReturnObject = SessionObject;
            }
            return ReturnObject;
        }

        public static void AddSession(string _key, object _value)
        {
            HttpContext.Current.Session.Add(_key, _value);
        }

        #endregion


        public static void RemoveSession(string _key)
        {
            var SessionObject = HttpContext.Current.Session[_key];
            if (SessionObject != null)
            {
                HttpContext.Current.Session.Remove(_key);
            }
        }
        #region "Cookie Helper"
        public static void AddCookie(string _key, string _value, int _numberOfHourAdd = 0)
        {
            HttpCookie CookieObject = new HttpCookie(_key);
            CookieObject.Value = _value;
            if (_numberOfHourAdd > 0)
            {
                CookieObject.Expires = GetUtcDateTime().AddHours(_numberOfHourAdd);
            }
            HttpContext.Current.Response.Cookies.Add(CookieObject);
        }
        public static void RemoveCookie(string _key)
        {
            HttpCookie CookieObject = HttpContext.Current.Request.Cookies[_key];
            if (CookieObject != null)
            {
                CookieObject.Expires = GetUtcDateTime().AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(CookieObject);
            }
        }
        public static string GetCookie(string _key)
        {
            string ReturnValue = string.Empty;
            HttpCookie CookieObject = HttpContext.Current.Request.Cookies[_key];
            if (CookieObject != null)
            {
                ReturnValue = CookieObject.Value;
            }
            return ReturnValue;
        }
        public static string ConvertToWebURL(Uri requestUrl, string str)
        {
            return "http://" + requestUrl.Authority + "/" + str;
        }

        #endregion

        public class AjaxResponse
        {
            public bool Success { get; set; }
            public string Type { get; set; }
            public string FieldName { get; set; }
            public string Message { get; set; }
            public string TargetURL { get; set; }
            public string Data { get; set; }
        }
        public static string GetViewName(string _name)
        {
            return "~/Views/" + _name + ".cshtml";
        }
        public static DateTime GetUtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
