
using Quantrix_Git.Models;
using Quantrix_Git;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Quantrix_Git.Controllers
{
    public class HomePageContentController : Controller
    {
        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Save(int hdnAddressID, string Content_text)
        {
            ResultObject result_object = new ResultObject();
            HomePageContent HomePageContent_object = new HomePageContent();
            HomePageContent_object.Save(hdnAddressID, Content_text,  result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult Search(int? home_page_Content_id, string searchText, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageContent HomePageContent_object = new HomePageContent();
            HomePageContent_object.Search(home_page_Content_id, searchText, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [NoDirectAccess]
        [UserSessionActionFilter]
        public ActionResult ChangeStatus(int? home_page_Content_id, int status)
        {
            ResultObject result_object = new ResultObject();
            HomePageContent HomePageContent_object = new HomePageContent();
            HomePageContent_object.ChangeStatus(home_page_Content_id, status, result_object);
            return Json(result_object, JsonRequestBehavior.AllowGet);
        }   
	}
}