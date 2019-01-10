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
    public class CityController : Controller
    {
        // GET: BrachesSetup

       [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.CityDataAccess bda = new LHRLA.DAL.DataAccessClasses.CityDataAccess();
            var list = bda.GetAllCity();
            //ViewBag.City = null;
            return View(list);
        }

       
        public ActionResult AddUpdateCity(tbl_City request)
        {
          
            LHRLA.DAL.DataAccessClasses.CityDataAccess bda = new LHRLA.DAL.DataAccessClasses.CityDataAccess();
            var Name = request.Name.ToLower().Trim();
            var CityExistData = bda.GetCitybyIDOfExistingName(request.ID, Name);
            var NameExistValue = CityExistData.Select(o => o.Name).FirstOrDefault();
            var NameData = bda.GetCitybyIDName(request.ID, Name);
            var NameValue = NameData.Select(o => o.Name).FirstOrDefault();
            var flag = true;
            if (request.ID > 0)
            {
                if (NameValue != Name)
                {
                    flag = bda.UpdateCity(request);

                }
                else if (NameExistValue == Name)
                {
                    flag = bda.UpdateCity(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = bda.CheckDuplicateData(Name);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = bda.AddCity(request);
                }
            }


          //  var flag = request.ID > 0 ? bda.UpdateCity(request) : bda.AddCity(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "City") : null }, JsonRequestBehavior.AllowGet);
        }

      [AuthOp]
        public ActionResult Index(int ? id)
        {
            if (id == 0)
            {
                return View();

            }
            int Cityid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CityDataAccess bda = new LHRLA.DAL.DataAccessClasses.CityDataAccess();
            var flag = bda.GetCitybyID(Cityid).FirstOrDefault();
            return View(flag);
        }
        
    }
}