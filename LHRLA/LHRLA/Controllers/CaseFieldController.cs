using LHRLA.Core.Helpers;
using LHRLA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LHRLA.Controllers
{
    public class CaseFieldController : Controller
    {
        List<tbl_Case_Fields_Options> options = new List<tbl_Case_Fields_Options>();
        // GET: CaseField
        [AuthOp]
        public ActionResult Index(int? id)
        {
            int ID = Convert.ToInt32(id);
            ViewBag.DataBySectionID = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs().GetCaseFieldsbyID(ID);
            ViewBag.SectionList = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs().GetAllCaseFieldsSections();
            ViewBag.Options = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs().GetOptionsByFieldID(ID);
            return View();
        }

        [HttpPost]
        public JsonResult GetField(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var data = new SelectList(cfd.GetCaseFieldlbySectionID(ID), "ID", "Name");
            return Json(data);
        }
        public JsonResult GetActiveValuesOfCaseSection(int? id)
        {
            int ID = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var flag = (cfd.GetAllCaseFieldsBySectionID(ID).FirstOrDefault());
            return Json(new { IsSuccess = true, Is_Active = flag.Is_Active }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetActiveValuesOfCaseField(int? id)
        {
            int ID = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var flag = (cfd.GetCaseFieldsbyID(ID).FirstOrDefault());
            return Json(new { IsSuccess = true, Is_Active = flag.Is_Active, Is_Encrypted = flag.Is_Encrypted, Is_Visible_On_App = flag.Is_Visible_On_App }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetSectionSequence(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess();
            var data = new SelectList(cfd.GetCaseFiledsSectionbyID(ID), "ID", "Sequence_No");
            return Json(data);
        }

        public JsonResult GetFieldSequence(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var data = new SelectList(cfd.GetCaseFieldsbyID(ID), "ID", "Sequence_No");
            return Json(data);
        }

        public JsonResult GetOption(int? id)
        {
            int ID = Convert.ToInt32(id);

            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            return Json(new SelectList(cfd.GetCaseFieldlbySectionID(ID), "ID", "Name"));
        }

        [HttpPost]

        public ActionResult AddUpdateSection(tbl_Case_Fields_Section request)
        {

            LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess cfs = new LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess();
            var flag = request.ID > 0 ? cfs.UpdateCaseFiledsSection(request) : cfs.AddCaseFiledsSection(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseField") : null }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddUpdateField(tbl_Case_Fields request)
        {

            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var flag = request.ID > 0 ? cfd.UpdateCaseFields(request) : cfd.AddCaseFields(request);

            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseField") : null }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetOptionOnChangeField(int? id)
        {
            int ID = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            List<Core.ViewModel.FieldOptionVM> _Option = cfd.GetOptionsByFieldID(ID).Select(x => new Core.ViewModel.FieldOptionVM
            {
                Id = x.ID,
                Name = x.Name,
            }).ToList();
            // ViewBag.OptionsOnChange = cfd.GetOptionsByFieldID(ID);
            return Json(_Option);

        }
        public ActionResult EditSection(string ID)
        {



            int SectionId = Convert.ToInt32(ID);
            LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess cfs = new LHRLA.DAL.DataAccessClasses.CaseFieldsSectionDataAccess();
            var Section = cfs.GetCaseFiledsSectionbyID(SectionId);
            return Json(new { result = Section.Select(o => o.Name).FirstOrDefault() }, JsonRequestBehavior.AllowGet);
            //   return Json((ctd.GetCaseSubTypeID(CaseId)), JsonRequestBehavior.AllowGet);

        }

        public ActionResult EditField(string ID)
        {

            int FieldID = Convert.ToInt32(ID);
            LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsDataAccesscs();
            var Field = cfd.GetCaseFieldsbyID(FieldID);
            return Json(new { result = Field.Select(o => o.Name).FirstOrDefault() }, JsonRequestBehavior.AllowGet);


        }


        public ActionResult AddOption(tbl_Case_Fields_Options request)
        {

            LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess();
            //var flag = cfd.AddCaseFieldsOptions(request);
            var flag = true;
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseField") : null }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save(tbl_Case_Fields_Options request)
        {
            LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess();
            List<tbl_Case_Fields_Options> ListOption = new List<tbl_Case_Fields_Options>();
            var flag = true;
            int ID = Convert.ToInt32(request.Case_Field_ID);
            if(ID > 0)
            {
                if (request.Name != null)
                {
                    bool IsDeleted = cfd.DeleteCaseFieldsOptionsById(ID);
                    if (IsDeleted)
                    {

                        string[] splitOptions = new string[] { };
                        splitOptions =request.Name.Split('/');
                        for (int i = 0; i < splitOptions.Length-1; i++)
                        {
                            tbl_Case_Fields_Options ds = new tbl_Case_Fields_Options();
                            ds.Case_Field_ID = request.Case_Field_ID;
                            ds.Name = splitOptions[i];
                            ds.Is_Active = true;
                            ListOption.Add(ds);
                        }
                        flag = cfd.AddCaseFieldsOptionsList(ListOption);
                    }
                }
            }
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseField") : null }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InActiveOption(tbl_Case_Fields_Options request)
        {
            LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess cfd = new LHRLA.DAL.DataAccessClasses.CaseFieldsOptionsDataAccess();
            var flag = cfd.InActiveOptions(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseField") : null }, JsonRequestBehavior.AllowGet);
        }

        ///
    }
}