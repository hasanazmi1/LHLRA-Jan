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
    public class CaseTagsController : Controller
    {
        // GET: CaseTags
       [AuthOp]
        public ActionResult List()
        {
            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess ctd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var list = ctd.GetAllTagsSetup();
            //ViewBag.City = null;
            return View(list);
        }


        public ActionResult AddUpdateCaseTags(tbl_Tags_Setup request)
        {

            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess ctd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var Tag = request.Tag_Value.ToLower().Trim();
            var TagData = ctd.GetTagsSetupbyIDOnUpdate(request.ID,Tag);
            var TagValue = TagData.Select(o => o.Tag_Value).FirstOrDefault();
            var TagExistingData = ctd.GetTagsSetupbyIDValue(request.ID, Tag);
            var TagExistingValue = TagExistingData.Select(o => o.Tag_Value).FirstOrDefault();
            var flag = true;
            if (request.ID > 0)
            {
                if (TagValue != Tag)
                {
                    flag = ctd.UpdateTagsSetup(request);

                }
                else if (TagExistingValue == Tag)
                {
                    flag = ctd.UpdateTagsSetup(request);
                }
                else
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }
            }
            //  var flag = request.ID > 0 ? bda.UpdateBranch(request) : bda.AddBranch(request);
            else
            {
                var CheckDuplicate = ctd.CheckDuplicateData(Tag);
                if (CheckDuplicate.Count > 0)
                {
                    return Json(new { IsSuccess = false, ErrorMessage = (flag == false) ? CustomMessages.DuplicateEmail : CustomMessages.GenericErrorMessage, Response = (flag == false) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);

                }

                else
                {
                    flag = ctd.AddTagsSetup(request);
                }
            }

          //  var flag = request.ID > 0 ? ctd.UpdateTagsSetup(request) : ctd.AddTagsSetup(request);
            return Json(new { IsSuccess = flag, ErrorMessage = (flag == true) ? CustomMessages.Success : CustomMessages.GenericErrorMessage, Response = (flag == true) ? Url.Action("Index", "CaseTags") : null }, JsonRequestBehavior.AllowGet);
        }

       [AuthOp]
        public ActionResult Index(int? id)
        {
            if (id == 0)
            {
                return View();

            }
            int CaseTagsid = Convert.ToInt32(id);
            LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess ctd = new LHRLA.DAL.DataAccessClasses.TagsSetupDataAccess();
            var flag = ctd.GetTagsSetupbyID(CaseTagsid).FirstOrDefault();
            return View(flag);
        }
    }
}