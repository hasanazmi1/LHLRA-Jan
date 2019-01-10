using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LHRLA.LHRLA.DAL.DataAccessClasses;
using LHRLA.Core.Helpers;

namespace LHRLA.Controllers
{
    [SessionAttribute]
    public class CaseCategoriesController : Controller
    {
        // GET: CaseCategories
        [AuthOp]
        public ActionResult Index(int? id)
        {
            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            int ID = Convert.ToInt32(id);
            //  ViewBag.DataById = ctd.GetCaseTypesbyID(ID).FirstOrDefault();
            ViewBag.List = ctd.GetAllCaseTypes().ToList();

            return View();
        }
        public JsonResult GetCase(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var flag = ctd.GetCaseSubTypeID(ID);
            return Json(new SelectList(ctd.GetCaseTypesbyCaseSubTypeID(ID), "ID", "Type"), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetActiveValuesOfCaseSubType(int? id)
        {
            int ID = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var flag = (ctd.GetCaseSubTypeValue(ID).FirstOrDefault());
            return Json(new { IsSuccess = true, Is_Active = flag.Is_Active}, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetActiveValuesOfCaseMainType(int? id)
        {
            int ID = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var flag = (ctd.GetCaseTypesbyID(ID).FirstOrDefault());
            return Json(new { IsSuccess = true, Is_Active = flag.Is_Active }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]

        public ActionResult AddUpdateCaseSubType(tbl_Case_Sub_Types request)
        {

            LHRLA.DAL.DataAccessClasses.CaseSubTypesDataAccess csb = new LHRLA.DAL.DataAccessClasses.CaseSubTypesDataAccess();
            var flag = request.ID > 0 ? csb.UpdateCaseSubTypes(request) : csb.AddCaseSubTypes(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("BranchesSetupList", "Branch") : null }, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult AddUpdateCaseType(tbl_Case_Types request)
        {

            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var flag = request.ID > 0 ? ctd.UpdateCaseTypes(request) : ctd.AddCaseTypes(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("BranchesSetupList", "Branch") : null }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCaseSubType(string ID)
        {



            int CaseId = Convert.ToInt32(ID);
            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var Case = ctd.GetCaseSubTypeID(CaseId);
            return Json(new { result = Case.Select(o => o.Type).FirstOrDefault() }, JsonRequestBehavior.AllowGet);
            // return Json((ctd.GetCaseSubTypeID(CaseId)), JsonRequestBehavior.AllowGet);

        }
        //                


        public ActionResult EditCaseType(string ID)
        {



            int CaseId = Convert.ToInt32(ID);
            LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess ctd = new LHRLA.DAL.DataAccessClasses.CaseTypesDataAccess();
            var Case = ctd.GetCaseTypesbyID(CaseId);
            return Json(new { result = Case.Select(o => o.Type).FirstOrDefault() }, JsonRequestBehavior.AllowGet);




        }

    }
}